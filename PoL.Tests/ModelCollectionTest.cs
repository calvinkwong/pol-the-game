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
		public void ShouldSyncItsContainerWithModelParents()
		{
			var model_a = new Model ("a");
			var model_b = new Model ("b");
			var model_container = new Model("container");
			var models = new ModelCollection(model_container);
			models.AddRange(new [] {model_a, model_b});

			Assert.That(models.Container, Is.EqualTo(model_container));
			Assert.That(models.All(m => m.Parent == model_container));

			models.Clear();
			
	        Assert.That(model_a.Parent, Is.Null);
			Assert.That(model_b.Parent, Is.Null);
			
			models.Add(model_a);
			
			Assert.That(model_a.Parent, Is.EqualTo(model_container));
			
			models.Insert(0, model_b);
			
			Assert.That(model_b.Parent, Is.EqualTo(model_container));
			
			models.Remove(model_a);
			
			Assert.That(model_a.Parent, Is.Null);
		}
	}
}