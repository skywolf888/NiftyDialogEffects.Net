//package com.gitonway.lee.niftymodaldialogeffects.lib.effects;

//import android.view.View;

//import com.nineoldandroids.animation.ObjectAnimator;

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
using Android.Animation;
using Android.Views;

namespace Com.Gitonway.Lee.Niftymodaldialogeffects.Lib.Effects
{
    public class RotateLeft : BaseEffects
    {

        //@Override
        protected override void setupAnimation(View view)
        {
            getAnimatorSet().PlayTogether(
                    ObjectAnimator.OfFloat(view, "rotationY", 90, 0).SetDuration(mDuration),
                    ObjectAnimator.OfFloat(view, "translationX", -300, 0).SetDuration(mDuration),
                    ObjectAnimator.OfFloat(view, "alpha", 0, 1).SetDuration(mDuration * 3 / 2)

            );
        }
    }
}