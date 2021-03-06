using System;
using System.Collections.Generic;
using Android.Widget;
using Tasky.BL;
using Android.App;
using Android;

namespace TaskyAndroid.Adapters {
	public class TaskListAdapter : BaseAdapter<TaskItem> {
		protected Activity context = null;
		protected IList<TaskItem> taskItems = new List<TaskItem>();
		
		public TaskListAdapter (Activity context, IList<TaskItem> taskItems) : base ()
		{
			this.context = context;
			this.taskItems = taskItems;
		}
		
		public override TaskItem this[int position]
		{
			get { return taskItems[position]; }
		}
		
		public override long GetItemId (int position)
		{
			return position;
		}
		
		public override int Count
		{
			get { return taskItems.Count; }
		}
		
		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			// Get our object for position
			var item = taskItems[position];			

			//Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
			// gives us some performance gains by not always inflating a new view
			// will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
			var view = (convertView ?? 
					context.LayoutInflater.Inflate(
					Android.Resource.Layout.SimpleListItemChecked,
					parent, 
					false)) as CheckedTextView;

			view.SetText (item.Name==""?"<new task>":item.Name, TextView.BufferType.Normal);
			view.Checked = item.Done;
			
			//Finally return the view
			return view;
		}
	}
}