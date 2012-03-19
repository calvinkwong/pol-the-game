using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Patterns.ComponentModel;
	
namespace PoL.Tests
{
	[TestFixture]
	public class ModelCollectionTest
	{
		[Test]
		public void ShouldAcceptModelsInConstruction()
		{
			var models = new ModelCollection(new Model("a"), new Model("b"));
			
			Assert.That(models.Count(), Is.EqualTo(2));
			Assert.That(models.Container, Is.Null);
		}

		[Test]
		public void ShouldEmptyOnClearMessage()
		{
			var models = new ModelCollection(new Model("a"), new Model("b"));
			models.Clear();
			
			Assert.That(models.Count(), Is.EqualTo(0));
		}

		[Test]
		public void ShouldAppendOnAddMessage()
		{
			var models = new ModelCollection();
			Model model_a = new Model("a");
			Model model_b = new Model("b");
			models.AddRange(new [] {model_a, model_b});
			
			Assert.That(models.First(), Is.EqualTo(model_a));
			Assert.That(models.Last(), Is.EqualTo(model_b));
		}

		[Test]
		public void ShouldRemoveOnRemoveMessage()
		{
			Model model = new Model("a");
			var models = new ModelCollection(model);
			models.Remove(model);
			
			Assert.That(models.Count(), Is.EqualTo(0));
		}
		
		[Test]
		public void ShouldSyncContainerAndParents()
		{
			var model_a = new Model ("a");
			var model_b = new Model ("b");
			var model_container = new Model("container");
			var models = new ModelCollection(model_a, model_b).WithContainer(model_container);

			Assert.That(models.Container, Is.EqualTo(model_container));
			Assert.That(models.All(m => m.Parent == model_container));

			models.Clear();
			
	        Assert.That(model_a.Parent, Is.Null);
			Assert.That(model_b.Parent, Is.Null);
			
			models.Add(model_a);
			
			Assert.That(model_a.Parent, Is.EqualTo(model_container));
			
			models.Remove(model_a);
			
			Assert.That(model_a.Parent, Is.Null);
		}
	}
}