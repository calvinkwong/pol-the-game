/*
PoL - The polyhedral card game simulator
Copyright (C) 2011 Andrea Biagini

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/
//
//using System;
//using System.Collections.ObjectModel;
//using System.Collections.Specialized;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Collections;
//using System.Reflection;
//
//namespace Patterns.ComponentModel
//{
//  [Serializable]
//  public class ModelCollection : ObservableCollection<Model>, INotifyCollectionChanged
//  {
//    Model container;
//    bool suspended;
//
//    public ModelCollection(Model container, IEnumerable<Model> collection)
//      : base(collection)
//    {
//      this.container = container;
//    }
//
//    public ModelCollection(IEnumerable<Model> collection)
//      : this(null, collection) { }
//
//    public ModelCollection(Model container)
//    {
//      this.container = container;
//    }
//
//    public void AddRange(IEnumerable<Model> items)
//    {
//      var itemList = items.ToList();
//      if(itemList.Count > 0)
//      {
//        int startIndex = this.Count;
//        bool isSuspended = suspended;
//        suspended = true;
//        foreach(Model item in items)
//          Add(item);
//        suspended = isSuspended;
//        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, itemList, startIndex));
//      }
//    }
//
//    protected override void ClearItems()
//    {
//      var removedItems = this.ToList();
//      if(removedItems.Count > 0)
//      {
//        bool isSuspended = suspended;
//        suspended = true;
//        base.ClearItems();
//        suspended = isSuspended;
//        OnCollectionChanged(new ModelCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset) { OldItems = removedItems });
//      }
//    }
//
//    public void SuspendChangeNotifications()
//    {
//      if(!suspended)
//        suspended = true;
//    }
//
//    public void ResumeChangeNotifications()
//    {
//      if(suspended)
//      {
//        suspended = false;
//        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
//      }
//    }
//
////    public new event NotifyCollectionChangedEventHandler CollectionChanged;
////
////    event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
////    {
////      add { CollectionChanged += value; }
////      remove { CollectionChanged -= value; }
////    }
//
//    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
//    {
//      base.OnCollectionChanged(e);
//
//      switch(e.Action)
//      {
//        case NotifyCollectionChangedAction.Add:
//          foreach(Model model in e.NewItems)
//            model.SetParent(this.container);
//          break;
//        case NotifyCollectionChangedAction.Remove:
//          foreach(Model model in e.OldItems)
//            model.SetParent(null);
//          break;
//        case NotifyCollectionChangedAction.Replace:
//          throw new NotSupportedException("Replace NotifyCollectionChangedAction not supported!");
//        case NotifyCollectionChangedAction.Reset:
//          if(e.OldItems != null)
//            foreach(Model model in e.OldItems)
//              model.SetParent(null);
//          foreach(Model model in this)
//            model.SetParent(this.container);
//          break;
//      }
//
////      if(CollectionChanged != null && !suspended)
////        CollectionChanged(this, e);
//    }
//
//    public Model Container
//    {
//      get { return container; }
//    }
//  }
//
//  public class ModelCollectionChangedEventArgs : NotifyCollectionChangedEventArgs
//  {
//    public ModelCollectionChangedEventArgs(NotifyCollectionChangedAction action)
//      : base(action)
//    {
//    }
//
//    public ModelCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList items)
//      : base(action, items)
//    {
//      _oldItems = base.OldItems;
//    }
//
//    private IList _oldItems;
//    public new IList OldItems
//    {
//      get { return _oldItems; }
//      set
//      {
//        _oldItems = value;
//        try
//        {
//          typeof(NotifyCollectionChangedEventArgs).GetField("_oldItems", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this, value);
//        }
//        catch
//        {
//        }
//      }
//    }
//  }
//}

using System;
using System.Linq;
using System.Collections.Generic;

namespace Patterns.ComponentModel
{
	public delegate void CollectionChangedEventHandler(object sender, CollectionChangedEventArgs args);
	
	public class ObservableCollection<T> : IEnumerable<T>
	{
		public CollectionChangedEventHandler CollectionChanged;
		
		bool suspended = false;
		List<T> collection = new List<T>();
		
		public ObservableCollection(params T[] collection)
		{
			this.collection.AddRange(collection);
		}
		
		public IEnumerator<T> GetEnumerator()
		{
			return collection.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return collection.GetEnumerator();
		}
		
		public int Count
		{
			get { return collection.Count; }			
		}
		
		public T this[int index]
		{
			get { return collection[index]; }
		}
		
		public int IndexOf(T item)
		{
			return collection.IndexOf(item);
		}
		
		public virtual void Move(int fromIndex, int toIndex)
		{
			var item = collection[fromIndex];
			collection.RemoveAt(fromIndex);
			collection.Insert(toIndex, item);
			var args = new CollectionChangedEventArgs(CollectionChangedAction.Move);
			args.NewItems = new List<object> { item };
			args.StartIndex = fromIndex;
			args.EndIndex = toIndex;
			OnCollectionChanged(args);
		}
        
		public virtual void Insert(int index, T item)
		{
			collection.Insert(index, item);
			var args = new CollectionChangedEventArgs(CollectionChangedAction.Add);
			args.NewItems = new List<object> { item };
			args.StartIndex = index;
			OnCollectionChanged(args);
		}
		
		public virtual void Add(T item)
		{
			collection.Add(item);
			var args = new CollectionChangedEventArgs(CollectionChangedAction.Add);
			args.NewItems = new List<object> { item };
			args.StartIndex = collection.Count - 1;
			OnCollectionChanged(args);
		}
		
		public virtual void AddRange(IEnumerable<T> items)
		{
			if(items.Count() == 0)
				return;
			
			var startIndex = collection.Count();
			var isSuspended = suspended;
			suspended = true;
			foreach(var item in items)
				Add(item);
			suspended = isSuspended;
			var args = new CollectionChangedEventArgs(CollectionChangedAction.Add);
			args.NewItems = items.Cast<object>().ToList();
			args.StartIndex = startIndex;
			OnCollectionChanged(args);
		}

		public virtual void Remove(T item)
		{
			var i = collection.IndexOf(item);
			collection.RemoveAt(i);
			var args = new CollectionChangedEventArgs(CollectionChangedAction.Remove);
			args.OldItems = new List<object> { item };
			args.StartIndex = i;
			OnCollectionChanged(args);
		}
		
		public virtual void Clear()
		{
			var removedItems = collection.ToList();
			collection.Clear();
			var args = new CollectionChangedEventArgs(CollectionChangedAction.Reset);
			args.OldItems = removedItems.Cast<object>().ToList();
			OnCollectionChanged(args);
		}
		        
		public void SuspendChangeNotifications()
		{
			suspended = true;
		}
		
		public void ResumeChangeNotifications()
		{
			if(suspended) {				
				suspended = false;
				var args = new CollectionChangedEventArgs(CollectionChangedAction.Reset);
				OnCollectionChanged(args);
			}
		}
		
		void OnCollectionChanged(CollectionChangedEventArgs args)
		{
			if(!suspended && CollectionChanged != null)
				CollectionChanged(this, args);
		}       
	}

	public enum CollectionChangedAction
	{
		Add = 0,
		Remove = 1,
		Replace = 2,
		Move = 3,
		Reset = 4,
	}
	
	public class CollectionChangedEventArgs
	{
		public CollectionChangedAction Action;
		public List<object> OldItems = new List<object>();
		public List<object> NewItems = new List<object>();
		public int StartIndex = -1;
		public int EndIndex = -1;
		
		public  CollectionChangedEventArgs(CollectionChangedAction action = CollectionChangedAction.Add)
		{
			this.Action = action;
		}
	}
	
	[Serializable]
	public class ModelCollection : ObservableCollection<Model>
	{
		Model container;
		
		public ModelCollection(params Model[] models)
			: base(models)
		{
		}
		
		public ModelCollection WithContainer(Model container)
		{
			this.container = container;
			foreach(var item in this) 
				item.SetParent(container);
			return this;
		}
		
		public override void Clear()
		{
			foreach(var item in this) 
				item.SetParent(null);
			base.Clear();			
		}

		public override void Add(Model model)
		{
			model.SetParent(container);
			base.Add(model);
		}
		
		public override void AddRange(IEnumerable<Model> models)
		{
			foreach(var model in models) 
				model.SetParent(container);
			base.AddRange(models);
		}
		
		public override void Remove(Model model)
		{
			model.SetParent(null);
			base.Remove(model);
		}
		
		public Model Container
		{
			get { return container; }
		}
	}
}