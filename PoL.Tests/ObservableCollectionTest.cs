using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Patterns;
using Patterns.ComponentModel;

namespace PoL.Tests
{
	[TestFixture]
	public class ObservableCollectionTest
	{
		CollectionChangedEventArgs args;
		ObservableCollection<int> collection;
		
		[SetUp]
		public void SetUp()
		{
			args = new CollectionChangedEventArgs();
			collection = new ObservableCollection<int>();
			collection.CollectionChanged += CallbackCollectionChanged;			
		}
		
		[TearDown]
		public void teardown()
		{
			collection.CollectionChanged -= CallbackCollectionChanged;						
		}
        
		[Test]
		public void ShouldAcceptItemsInConstruction()
		{
			collection = new ObservableCollection<int>(new [] {1,2,3});
			Assert.That(collection.Count(), Is.EqualTo(3));
			Assert.That(collection.ElementAt(1), Is.EqualTo(2));
		}
        
		[Test]
		public void ShouldAddItems()
		{
			collection.Add(4);
			Assert.That(collection.Count(), Is.EqualTo(1));
			Assert.That(collection.First(), Is.EqualTo(4));
		}
		
		[Test]
		public void ShouldAddItemsAtGivenIndex()
		{
			collection.AddRange(new [] {1,2,3});
			collection.Insert(1, 4);
			Assert.That(collection.Count(), Is.EqualTo(4));
			Assert.That(collection.ElementAt(1), Is.EqualTo(4));
		}

		[Test]
		public void ShouldRemoveItems()
		{
			collection.AddRange(new [] {1,2,3});
			collection.Remove(1);
			Assert.That(collection.Count(), Is.EqualTo(2));
			Assert.That(collection.Last(), Is.EqualTo(3));
		}

		[Test]
		public void ShouldClearItems()
		{
			collection.AddRange(new [] {1,2,3});
			collection.Clear();
			Assert.That(collection.Count(), Is.EqualTo(0));
		}

		[Test]
		public void ShouldAddItemsInBlock()
		{
			collection.AddRange(new [] {1,2,3});
			Assert.That(collection.Count(), Is.EqualTo(3));
			Assert.That(collection.ElementAt(1), Is.EqualTo(2));
		}

		[Test]
		public void ShouldMoveItemsAtGivenIndexes()
		{
			collection.AddRange(new [] {1,2,3});
			collection.Move(0, 2);
			Assert.That(collection.ElementAt(0), Is.EqualTo(2));
			Assert.That(collection.ElementAt(1), Is.EqualTo(3));
			Assert.That(collection.ElementAt(2), Is.EqualTo(1));
		}

		[Test]
		public void ShouldNotifyWhenAddItem()
		{
			var item = 1;
			collection.Add(item);
			Assert.That(args.NewItems.Count, Is.EqualTo(1));
			Assert.That(args.OldItems.Count, Is.EqualTo(0));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Add));
			Assert.That(args.StartIndex, Is.EqualTo(0));
			Assert.That(args.NewItems, Is.EquivalentTo(new [] { item }));
		}

		[Test]
		public void ShouldNotifyWhenMoveItem()
		{
			var items = new [] {1, 2};
			collection.AddRange(items);
			collection.Move(0, 1);
			Assert.That(args.NewItems.Count, Is.EqualTo(0));
			Assert.That(args.OldItems.Count, Is.EqualTo(1));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Move));
			Assert.That(args.StartIndex, Is.EqualTo(0));
			Assert.That(args.EndIndex, Is.EqualTo(1));
			Assert.That(args.OldItems, Is.EquivalentTo(new [] { 1 }));
		}

		[Test]
		public void ShouldNotifyWhenRemoveItem()
		{
			var items = new [] {1, 2};
			collection.AddRange(items);
			collection.Remove(2);
			Assert.That(args.NewItems.Count, Is.EqualTo(0));
			Assert.That(args.OldItems.Count, Is.EqualTo(1));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Remove));
			Assert.That(args.StartIndex, Is.EqualTo(1));
			Assert.That(args.OldItems, Is.EquivalentTo(new [] { 2 }));
		}

		[Test]
		public void ShouldNotifyWhenClearItems()
		{
			var item = 1;
			collection.Add(item);
			collection.Clear();
			Assert.That(args.NewItems.Count, Is.EqualTo(0));
			Assert.That(args.OldItems.Count, Is.EqualTo(1));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Reset));
			Assert.That(args.StartIndex, Is.EqualTo(-1));
			Assert.That(args.OldItems, Is.EquivalentTo(new [] { item }));
		}

		[Test]
		public void ShouldNotifyWhenAddItemsInBlock()
		{
			var items = new [] {1, 2};
			collection.AddRange(items);
			Assert.That(args.NewItems.Count, Is.EqualTo(2));
			Assert.That(args.OldItems.Count, Is.EqualTo(0));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Add));
			Assert.That(args.StartIndex, Is.EqualTo(0));
			Assert.That(args.NewItems, Is.EquivalentTo(items));
			collection.CollectionChanged -= CallbackCollectionChanged;
		}
		
		[Test]
		public void ShouldNotNotifyWhenSuspended()
		{
			collection.SuspendChangeNotifications();
			collection.Add(3);
			Assert.That(args.NewItems.Count, Is.EqualTo(0));
			Assert.That(args.OldItems.Count, Is.EqualTo(0));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Add));
			Assert.That(args.StartIndex, Is.EqualTo(-1));
		}
		
		[Test]
		public void ShouldNotifyAResetWhenResumed()
		{
			collection.SuspendChangeNotifications();
			collection.ResumeChangeNotifications();
			Assert.That(args.NewItems.Count, Is.EqualTo(0));
			Assert.That(args.OldItems.Count, Is.EqualTo(0));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Reset));
			Assert.That(args.StartIndex, Is.EqualTo(-1));
		}

		void CallbackCollectionChanged(object sender, CollectionChangedEventArgs args)
		{
			this.args = args;
		}
	}
}