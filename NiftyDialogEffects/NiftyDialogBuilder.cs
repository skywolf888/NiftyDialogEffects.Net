//package com.gitonway.lee.niftymodaldialogeffects.lib;

//import android.app.Activity;
//import android.app.Dialog;
//import android.content.Context;
//import android.content.DialogInterface;
//import android.graphics.Color;
//import android.graphics.drawable.Drawable;
//import android.os.Bundle;
//import android.util.Log;
//import android.view.View;
//import android.view.ViewGroup;
//import android.view.WindowManager;
//import android.widget.Button;
//import android.widget.FrameLayout;
//import android.widget.ImageView;
//import android.widget.LinearLayout;
//import android.widget.RelativeLayout;
//import android.widget.TextView;

//import com.gitonway.lee.niftymodaldialogeffects.lib.effects.BaseEffects;



using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Gitonway.Lee.Niftymodaldialogeffects.Lib.Effects;
using System;
using R = NiftyDialogEffects.Net.Resource;


namespace Com.Gitonway.Lee.Niftymodaldialogeffects.Lib
{
    /*
     * Copyright 2014 litao
     * https://github.com/sd6352051/NiftyDialogEffects
     *
     * Licensed under the Apache License, Version 2.0 (the "License");
     * you may not use this file except in compliance with the License.
     * You may obtain a copy of the License at
     *
     *     http://www.apache.org/licenses/LICENSE-2.0
     *
     * Unless required by applicable law or agreed to in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     */
    public class NiftyDialogBuilder : Dialog, IDialogInterface
    {

        private string defTextColor = "#FFFFFFFF";

        private string defDividerColor = "#11000000";

        private string defMsgColor = "#FFFFFFFF";

        private string defDialogColor = "#FFE74C3C";


        private static Context tmpContext;


        private Effectstype type ;

        private LinearLayout mLinearLayoutView;

        private RelativeLayout mRelativeLayoutView;

        private LinearLayout mLinearLayoutMsgView;

        private LinearLayout mLinearLayoutTopView;

        private FrameLayout mFrameLayoutCustomView;

        private View mDialogView;

        private View mDivider;

        private TextView mTitle;

        private TextView mMessage;

        private ImageView mIcon;

        private Button mButton1;

        private Button mButton2;

        private int mDuration = -1;

        private static int mOrientation = 1;

        private bool misCancelable = true;

        private static NiftyDialogBuilder instance;

        public NiftyDialogBuilder(Context context)
            :base(context)
        {
            
            init(context);

        }
        public NiftyDialogBuilder(Context context, int theme)
            :base(context, theme)
        {
            
            init(context);
        }

        //@Override
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            WindowManagerLayoutParams lparams = Window.Attributes;
            lparams.Height = ViewGroup.LayoutParams.MatchParent;
            lparams.Width = ViewGroup.LayoutParams.MatchParent;
            Window.Attributes=(Android.Views.WindowManagerLayoutParams)lparams;

        }

        private static object mlock=new Object();

        public static NiftyDialogBuilder getInstance(Context context)
        {

             
            if (instance == null || !tmpContext.Equals(context)) {
                lock (mlock) {
                    if (instance == null || !tmpContext.Equals(context)) {
                        instance = new NiftyDialogBuilder(context,R.Style.dialog_untran);
                    }
                }
            }
            tmpContext = context;
            return instance;

        }

        private void init(Context context)
        {

            mDialogView = View.Inflate(context, R.Layout.dialog_layout, null);

            mLinearLayoutView = (LinearLayout)mDialogView.FindViewById(R.Id.parentPanel);
            mRelativeLayoutView = (RelativeLayout)mDialogView.FindViewById(R.Id.main);
            mLinearLayoutTopView = (LinearLayout)mDialogView.FindViewById(R.Id.topPanel);
            mLinearLayoutMsgView = (LinearLayout)mDialogView.FindViewById(R.Id.contentPanel);
            mFrameLayoutCustomView = (FrameLayout)mDialogView.FindViewById(R.Id.customPanel);

            mTitle = (TextView)mDialogView.FindViewById(R.Id.alertTitle);
            mMessage = (TextView)mDialogView.FindViewById(R.Id.message);
            mIcon = (ImageView)mDialogView.FindViewById(R.Id.icon);
            mDivider = mDialogView.FindViewById(R.Id.titleDivider);
            mButton1 = (Button)mDialogView.FindViewById(R.Id.button1);
            mButton2 = (Button)mDialogView.FindViewById(R.Id.button2);

            SetContentView(mDialogView);
            
            //this.setOnShowListener(new OnShowListener() {
            //    @Override
            //    public void onShow(DialogInterface dialogInterface) {

            //        mLinearLayoutView.Visibility=View.VISIBLE);
            //        if(type==null){
            //            type=Effectstype.Slidetop;
            //        }
            //        start(type);
            
            this.ShowEvent +=delegate{
                             mLinearLayoutView.Visibility=ViewStates.Visible;
                    if(type==null){
                        type=Effectstype.Slidetop;
                    }
                    start(type);  
        };

            //    }
            //});
            //mRelativeLayoutView.setOnClickListener(new View.OnClickListener() {
            //    @Override
            //    public void onClick(View view) {
            //        if (isCancelable)dismiss();
            //    }
            //});

            mRelativeLayoutView.Click += delegate
            {
                if (misCancelable)
                    Dismiss();
            };
        }

        public void toDefault()
        {
            mTitle.SetTextColor(Color.ParseColor(defTextColor));
            mDivider.SetBackgroundColor(Color.ParseColor(defDividerColor));
            mMessage.SetTextColor(Color.ParseColor(defMsgColor));
            mLinearLayoutView.SetBackgroundColor(Color.ParseColor(defDialogColor));
        }

        public NiftyDialogBuilder withDividerColor(string colorString)
        {
            mDivider.SetBackgroundColor(Color.ParseColor(colorString));
            return this;
        }
        public NiftyDialogBuilder withDividerColor(Color color)
        {
            mDivider.SetBackgroundColor(color);
            return this;
        }


        public NiftyDialogBuilder withTitle(string title)
        {
            toggleView(mLinearLayoutTopView, title);
            mTitle.Text=title;
            return this;
        }

        public NiftyDialogBuilder withTitleColor(string colorString)
        {
            mTitle.SetTextColor(Color.ParseColor(colorString));
            return this;
        }

        public NiftyDialogBuilder withTitleColor(Color color)
        {
            mTitle.SetTextColor(color);
            return this;
        }

        public NiftyDialogBuilder withMessage(int textResId)
        {
            toggleView(mLinearLayoutMsgView, textResId);
            mMessage.SetText(textResId);
            return this;
        }

        public NiftyDialogBuilder withMessage(string msg)
        {
            toggleView(mLinearLayoutMsgView, msg);
            mMessage.Text=msg;
            return this;
        }
        public NiftyDialogBuilder withMessageColor(string colorString)
        {
            mMessage.SetTextColor(Color.ParseColor(colorString));
            return this;
        }
        public NiftyDialogBuilder withMessageColor(Color color)
        {
            mMessage.SetTextColor(color);
            return this;
        }

        public NiftyDialogBuilder withDialogColor(string colorString)
        {
            mLinearLayoutView.Background.SetColorFilter(ColorUtils.getColorFilter(Color.ParseColor(colorString)));
            return this;
        }

        public NiftyDialogBuilder withDialogColor(int color)
        {
            mLinearLayoutView.Background.SetColorFilter(ColorUtils.getColorFilter(color));
            return this;
        }

        public NiftyDialogBuilder withIcon(int drawableResId)
        {
            mIcon.SetImageResource(drawableResId);
            return this;
        }

        public NiftyDialogBuilder withIcon(Drawable icon)
        {
            mIcon.SetImageDrawable(icon);
            return this;
        }

        public NiftyDialogBuilder withDuration(int duration)
        {
            this.mDuration = duration;
            return this;
        }

        public NiftyDialogBuilder withEffect(Effectstype type)
        {
            this.type = type;
            return this;
        }

        public NiftyDialogBuilder withButtonDrawable(int resid)
        {
            mButton1.SetBackgroundResource(resid);
            mButton2.SetBackgroundResource(resid);
            return this;
        }
        public NiftyDialogBuilder withButton1Text(string text)
        {
            mButton1.Visibility=ViewStates.Visible;
            mButton1.Text=text;

            return this;
        }
        public NiftyDialogBuilder withButton2Text(string text)
        {
            mButton2.Visibility=ViewStates.Visible;
            mButton2.Text=text;
            return this;
        }

        public Button Button1 { get { return mButton1; } }
        public Button Button2 { get { return mButton2; } }
        public NiftyDialogBuilder setButton1Click(View.IOnClickListener click)
        {
            mButton1.SetOnClickListener(click);
            return this;
        }

        public NiftyDialogBuilder setButton2Click(View.IOnClickListener click)
        {
            mButton2.SetOnClickListener(click);
            return this;
        }


        public NiftyDialogBuilder setCustomView(int resId, Context context)
        {
            View customView = View.Inflate(context, resId, null);
            if (mFrameLayoutCustomView.ChildCount > 0)
            {
                mFrameLayoutCustomView.RemoveAllViews();
            }
            mFrameLayoutCustomView.AddView(customView);
            return this;
        }

        public NiftyDialogBuilder setCustomView(View view, Context context)
        {
            if (mFrameLayoutCustomView.ChildCount > 0)
            {
                mFrameLayoutCustomView.RemoveAllViews();
            }
            mFrameLayoutCustomView.AddView(view);

            return this;
        }
        public NiftyDialogBuilder isCancelableOnTouchOutside(bool cancelable)
        {
            this.misCancelable = cancelable;
            this.SetCanceledOnTouchOutside(cancelable);
            return this;
        }

        public NiftyDialogBuilder isCancelable(bool cancelable)
        {
            this.misCancelable = cancelable;
            this.SetCancelable(cancelable);
            return this;
        }

        private void toggleView(View view, Object obj)
        {
            if (obj == null)
            {
                view.Visibility=ViewStates.Gone;
            }
            else
            {
                view.Visibility=ViewStates.Visible;
            }
        }
        //@Override
        public override void Show()
        {
            base.Show();
        }

        private void start(Effectstype type)
        {
            BaseEffects animator = EffectsHelper.getAnimator(type);
            if (mDuration != -1)
            {
                animator.setDuration(Math.Abs(mDuration));
            }
            animator.start(mRelativeLayoutView);
        }

        //@Override
        public override void Dismiss()
        {
            base.Dismiss();
            mButton1.Visibility=ViewStates.Gone;
            mButton2.Visibility=ViewStates.Gone;
        }
    }
}