package md5ea9257fae210c0c5127d800d09245f41;


public class ExamSchedulerAdapter_MyViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("OOP_Exercise.Adapters.ExamSchedulerAdapter+MyViewHolder, OOP Exercise", ExamSchedulerAdapter_MyViewHolder.class, __md_methods);
	}


	public ExamSchedulerAdapter_MyViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == ExamSchedulerAdapter_MyViewHolder.class)
			mono.android.TypeManager.Activate ("OOP_Exercise.Adapters.ExamSchedulerAdapter+MyViewHolder, OOP Exercise", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}