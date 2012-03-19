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

using System;
using System.Collections.Generic;

namespace Patterns
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
		public CollectionChangedAction action;
		public List<object> OldItems = new List<object>();
		public List<object> NewItems = new List<object>();
		public int StartIndex = -1;
		public int EndIndex = -1;
		
		public  CollectionChangedEventArgs(CollectionChangedAction action = CollectionChangedAction.Add)
		{
			this.action = action;
		}
	}		
}