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
		
		[Test]
		public void SetUp()
		{
			args = new CollectionChangedEventArgs();
		}
        
		[Test]
		public void Constructor()
		{
			var collection = new ObservableCollection<int>();
			Assert.That(collection.Count(), Is.EqualTo(0));
			collection = new ObservableCollection<int>(new [] {1,2,3});
			Assert.That(collection.Count(), Is.EqualTo(3));
			Assert.That(collection.ElementAt(1), Is.EqualTo(2));
		}
        
		[Test]
		public void Add()
		{
			var collection = new ObservableCollection<int>(new [] {1,2,3});
			collection.Add(4);
			Assert.That(collection.Count(), Is.EqualTo(4));
			Assert.That(collection.Last(), Is.EqualTo(4));
		}
		
		[Test]
		public void Insert()
		{
			var collection = new ObservableCollection<int>(new [] {1,2,3});
			collection.Insert(1, 4);
			Assert.That(collection.Count(), Is.EqualTo(4));
			Assert.That(collection.ElementAt(1), Is.EqualTo(4));
		}

		[Test]
		public void Remove()
		{
			var collection = new ObservableCollection<int>(new [] {1,2,3});
			collection.Remove(1);
			Assert.That(collection.Count(), Is.EqualTo(2));
			Assert.That(collection.Last(), Is.EqualTo(3));
		}

		[Test]
		public void Clear()
		{
			var collection = new ObservableCollection<int>(new [] {1,2,3});
			collection.Clear();
			Assert.That(collection.Count(), Is.EqualTo(0));
		}

		[Test]
		public void AddRange()
		{
			var collection = new ObservableCollection<int>();        
			collection.AddRange(new [] {1,2,3});
			Assert.That(collection.Count(), Is.EqualTo(3));
			Assert.That(collection.ElementAt(1), Is.EqualTo(2));
		}

		[Test]
		public void Move()
		{
			var collection = new ObservableCollection<int>(new [] {1,2,3});
			collection.Move(0, 2);
			Assert.That(collection.ElementAt(0), Is.EqualTo(2));
			Assert.That(collection.ElementAt(1), Is.EqualTo(3));
			Assert.That(collection.ElementAt(2), Is.EqualTo(1));
		}

		[Test]
		public void AddMessageSendsNotification()
		{
			var item = 1;
			var collection = new ObservableCollection<int>();
			collection.CollectionChanged += CallbackCollectionChanged;
			collection.Add(item);
			Assert.That(args.NewItems.Count, Is.EqualTo(1));
			Assert.That(args.OldItems.Count, Is.EqualTo(0));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Add));
			Assert.That(args.StartIndex, Is.EqualTo(0));
			Assert.That(args.NewItems, Is.EquivalentTo(new [] { item }));
			collection.CollectionChanged -= CallbackCollectionChanged;
		}

		[Test]
		public void RemoveMessageSendsNotification()
		{
			var items = new [] {1, 2};
			var collection = new ObservableCollection<int>(items);
			collection.CollectionChanged += CallbackCollectionChanged;
			collection.Remove(2);
			Assert.That(args.NewItems.Count, Is.EqualTo(0));
			Assert.That(args.OldItems.Count, Is.EqualTo(1));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Remove));
			Assert.That(args.StartIndex, Is.EqualTo(1));
			Assert.That(args.OldItems, Is.EquivalentTo(new [] { 2 }));
			collection.CollectionChanged -= CallbackCollectionChanged;
		}

		[Test]
		public void ClearMessageSendsNotification()
		{
			var item = 1;
			var collection = new ObservableCollection<int>(item);
			collection.CollectionChanged += CallbackCollectionChanged;
			collection.Clear();
			Assert.That(args.NewItems.Count, Is.EqualTo(0));
			Assert.That(args.OldItems.Count, Is.EqualTo(1));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Reset));
			Assert.That(args.StartIndex, Is.EqualTo(-1));
			Assert.That(args.OldItems, Is.EquivalentTo(new [] { item }));
			collection.CollectionChanged -= CallbackCollectionChanged;
		}

		[Test]
		public void AddRangeMessageSendsNotification()
		{
			var items = new [] {1, 2};
			var collection = new ObservableCollection<int>();
			collection.CollectionChanged += CallbackCollectionChanged;
			collection.AddRange(items);
			Assert.That(args.NewItems.Count, Is.EqualTo(2));
			Assert.That(args.OldItems.Count, Is.EqualTo(0));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Add));
			Assert.That(args.StartIndex, Is.EqualTo(0));
			Assert.That(args.NewItems, Is.EquivalentTo(items));
			collection.CollectionChanged -= CallbackCollectionChanged;
		}
		
		[Test]
		public void Suspension()
		{
			var item = 1;
			var collection = new ObservableCollection<int>(item);
			collection.CollectionChanged += CallbackCollectionChanged;
			collection.SuspendChangeNotifications();
			collection.Add(3);
			Assert.That(args.NewItems.Count, Is.EqualTo(0));
			Assert.That(args.OldItems.Count, Is.EqualTo(0));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Add));
			Assert.That(args.StartIndex, Is.EqualTo(-1));
			collection.ResumeChangeNotifications();
			Assert.That(args.NewItems.Count, Is.EqualTo(0));
			Assert.That(args.OldItems.Count, Is.EqualTo(0));
			Assert.That(args.Action, Is.EqualTo(CollectionChangedAction.Reset));
			Assert.That(args.StartIndex, Is.EqualTo(-1));
			collection.CollectionChanged -= CallbackCollectionChanged;
		}

		void CallbackCollectionChanged(object sender, CollectionChangedEventArgs args)
		{
			this.args = args;
		}
	}
}