package crc64bb0d992854e4ca09;


public class AndroidHorizontalListViewRenderer_DragAnDropItemTouchHelperCallback
	extends android.support.v7.widget.helper.ItemTouchHelper.Callback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_isLongPressDragEnabled:()Z:GetIsLongPressDragEnabledHandler\n" +
			"n_getMovementFlags:(Landroid/support/v7/widget/RecyclerView;Landroid/support/v7/widget/RecyclerView$ViewHolder;)I:GetGetMovementFlags_Landroid_support_v7_widget_RecyclerView_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_onSelectedChanged:(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V:GetOnSelectedChanged_Landroid_support_v7_widget_RecyclerView_ViewHolder_IHandler\n" +
			"n_onMove:(Landroid/support/v7/widget/RecyclerView;Landroid/support/v7/widget/RecyclerView$ViewHolder;Landroid/support/v7/widget/RecyclerView$ViewHolder;)Z:GetOnMove_Landroid_support_v7_widget_RecyclerView_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_onMoved:(Landroid/support/v7/widget/RecyclerView;Landroid/support/v7/widget/RecyclerView$ViewHolder;ILandroid/support/v7/widget/RecyclerView$ViewHolder;III)V:GetOnMoved_Landroid_support_v7_widget_RecyclerView_Landroid_support_v7_widget_RecyclerView_ViewHolder_ILandroid_support_v7_widget_RecyclerView_ViewHolder_IIIHandler\n" +
			"n_interpolateOutOfBoundsScroll:(Landroid/support/v7/widget/RecyclerView;IIIJ)I:GetInterpolateOutOfBoundsScroll_Landroid_support_v7_widget_RecyclerView_IIIJHandler\n" +
			"n_getMoveThreshold:(Landroid/support/v7/widget/RecyclerView$ViewHolder;)F:GetGetMoveThreshold_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_clearView:(Landroid/support/v7/widget/RecyclerView;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V:GetClearView_Landroid_support_v7_widget_RecyclerView_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_onSwiped:(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V:GetOnSwiped_Landroid_support_v7_widget_RecyclerView_ViewHolder_IHandler\n" +
			"";
		mono.android.Runtime.register ("Sharpnado.Presentation.Forms.Droid.Renderers.HorizontalList.AndroidHorizontalListViewRenderer+DragAnDropItemTouchHelperCallback, Sharpnado.Presentation.Forms.Droid", AndroidHorizontalListViewRenderer_DragAnDropItemTouchHelperCallback.class, __md_methods);
	}


	public AndroidHorizontalListViewRenderer_DragAnDropItemTouchHelperCallback ()
	{
		super ();
		if (getClass () == AndroidHorizontalListViewRenderer_DragAnDropItemTouchHelperCallback.class)
			mono.android.TypeManager.Activate ("Sharpnado.Presentation.Forms.Droid.Renderers.HorizontalList.AndroidHorizontalListViewRenderer+DragAnDropItemTouchHelperCallback, Sharpnado.Presentation.Forms.Droid", "", this, new java.lang.Object[] {  });
	}


	public boolean isLongPressDragEnabled ()
	{
		return n_isLongPressDragEnabled ();
	}

	private native boolean n_isLongPressDragEnabled ();


	public int getMovementFlags (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1)
	{
		return n_getMovementFlags (p0, p1);
	}

	private native int n_getMovementFlags (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1);


	public void onSelectedChanged (android.support.v7.widget.RecyclerView.ViewHolder p0, int p1)
	{
		n_onSelectedChanged (p0, p1);
	}

	private native void n_onSelectedChanged (android.support.v7.widget.RecyclerView.ViewHolder p0, int p1);


	public boolean onMove (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1, android.support.v7.widget.RecyclerView.ViewHolder p2)
	{
		return n_onMove (p0, p1, p2);
	}

	private native boolean n_onMove (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1, android.support.v7.widget.RecyclerView.ViewHolder p2);


	public void onMoved (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1, int p2, android.support.v7.widget.RecyclerView.ViewHolder p3, int p4, int p5, int p6)
	{
		n_onMoved (p0, p1, p2, p3, p4, p5, p6);
	}

	private native void n_onMoved (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1, int p2, android.support.v7.widget.RecyclerView.ViewHolder p3, int p4, int p5, int p6);


	public int interpolateOutOfBoundsScroll (android.support.v7.widget.RecyclerView p0, int p1, int p2, int p3, long p4)
	{
		return n_interpolateOutOfBoundsScroll (p0, p1, p2, p3, p4);
	}

	private native int n_interpolateOutOfBoundsScroll (android.support.v7.widget.RecyclerView p0, int p1, int p2, int p3, long p4);


	public float getMoveThreshold (android.support.v7.widget.RecyclerView.ViewHolder p0)
	{
		return n_getMoveThreshold (p0);
	}

	private native float n_getMoveThreshold (android.support.v7.widget.RecyclerView.ViewHolder p0);


	public void clearView (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1)
	{
		n_clearView (p0, p1);
	}

	private native void n_clearView (android.support.v7.widget.RecyclerView p0, android.support.v7.widget.RecyclerView.ViewHolder p1);


	public void onSwiped (android.support.v7.widget.RecyclerView.ViewHolder p0, int p1)
	{
		n_onSwiped (p0, p1);
	}

	private native void n_onSwiped (android.support.v7.widget.RecyclerView.ViewHolder p0, int p1);

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
