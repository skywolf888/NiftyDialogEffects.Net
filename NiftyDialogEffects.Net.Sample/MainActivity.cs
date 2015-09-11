using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Gitonway.Lee.Niftymodaldialogeffects.Lib;
using R=NiftyDialogEffects.Net.Sample.Resource;


namespace NiftyDialogEffects.Net.Sample
{
    [Activity(Label = "NiftyDialogEffects.Net.Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        private Effectstype effect;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);

            //// Get our button from the layout resource,
            //// and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            SetContentView(R.Layout.activity_main);
        }

        [Java.Interop.Export("dialogShow")]
        public void dialogShow(View v)
        {

            NiftyDialogBuilder dialogBuilder = NiftyDialogBuilder.getInstance(this);

            switch (v.Id)
            {
                case R.Id.fadein: effect = Effectstype.Fadein; break;
                case R.Id.slideright:effect=Effectstype.Slideright;break;
                case R.Id.slideleft: effect = Effectstype.Slideleft; break;
                case R.Id.slidetop: effect = Effectstype.Slidetop; break;
                case R.Id.slideBottom: effect = Effectstype.SlideBottom; break;
                case R.Id.newspager: effect = Effectstype.Newspager; break;
                case R.Id.fall: effect = Effectstype.Fall; break;
                case R.Id.sidefall: effect = Effectstype.Sidefill; break;
                case R.Id.fliph: effect = Effectstype.Fliph; break;
                case R.Id.flipv: effect = Effectstype.Flipv; break;
                case R.Id.rotatebottom: effect = Effectstype.RotateBottom; break;
                case R.Id.rotateleft: effect = Effectstype.RotateLeft; break;
                case R.Id.slit: effect = Effectstype.Slit; break;
                case R.Id.shake: effect = Effectstype.Shake; break;
            }


            dialogBuilder
                    .withTitle("Modal Dialog")                                  //.withTitle(null)  no title
                    .withTitleColor("#FFFFFF")                                  //def
                    .withDividerColor("#11000000")                              //def
                    .withMessage("This is a modal Dialog.")                     //.withMessage(null)  no Msg
                    .withMessageColor("#FFFFFFFF")                              //def  | withMessageColor(int resid)
                    .withDialogColor("#FFE74C3C")                               //def  | withDialogColor(int resid)                               //def
                    .withIcon(this.Resources.GetDrawable(R.Drawable.Icon))
                    .isCancelableOnTouchOutside(true)                           //def    | isCancelable(true)
                    .withDuration(700)                                          //def
                    .withEffect(effect)                                         //def Effectstype.Slidetop
                    .withButton1Text("OK")                                      //def gone
                    .withButton2Text("Cancel")                                  //def gone
                    .setCustomView(R.Layout.custom_view, v.Context);            //.setCustomView(View or ResId,context)
            dialogBuilder.Button1.Click += delegate
            {
                Toast.MakeText(this, "i'm btn1", ToastLength.Short).Show();
            };
            dialogBuilder.Button2.Click += delegate
            {
                Toast.MakeText(this, "i'm btn2", ToastLength.Short).Show();
            };

            //.setButton1Click(new View.OnClickListener() {
            //    @Override
            //    public void onClick(View v) {
            //        Toast.makeText(v.getContext(), "i'm btn1", Toast.LENGTH_SHORT).show();
            //    }
            //})
            //.setButton2Click(new View.OnClickListener() {
            //    @Override
            //    public void onClick(View v) {
            //        Toast.makeText(v.getContext(), "i'm btn2", Toast.LENGTH_SHORT).show();
            //    }
            //})
            dialogBuilder.Show();

        }       
    }

}