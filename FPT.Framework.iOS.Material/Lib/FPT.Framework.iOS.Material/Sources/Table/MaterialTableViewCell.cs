﻿//// MIT/X11 License
////
//// MaterialTableViewCell.cs
////
//// Author:
////       Pham Quan <QuanP@fpt.com.vn, mr.pquan@gmail.com> at FPT Software Service Center.
////
//// Copyright (c) 2016 FPT Information System.
////
//// Permission is hereby granted, free of charge, to any person obtaining a copy
//// of this software and associated documentation files (the "Software"), to deal
//// in the Software without restriction, including without limitation the rights
//// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//// copies of the Software, and to permit persons to whom the Software is
//// furnished to do so, subject to the following conditions:
////
//// The above copyright notice and this permission notice shall be included in
//// all copies or substantial portions of the Software.
////
//// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//// THE SOFTWARE.
//using System;
//using UIKit;
//using CoreAnimation;
//using System.Collections.Generic;
//using Foundation;
//using CoreGraphics;

//namespace FPT.Framework.iOS.Material
//{
//	public class MaterialTableViewCellAnimationDelegate : CAAnimationDelegate
//	{
//		MaterialTableViewCell mParent;

//		public MaterialTableViewCellAnimationDelegate(MaterialTableViewCell parent)
//		{
//			mParent = parent;
//		}

//		public override void AnimationStarted(CAAnimation anim)
//		{
//			if (mParent.Delegate is MaterialAnimationDelegate)
//			{
//				(mParent.Delegate as MaterialAnimationDelegate).materialAnimationDidStart(anim);
//			}
//		}

//		public override void AnimationStopped(CAAnimation anim, bool finished)
//		{
//			if (anim is CAPropertyAnimation)
//			{
//				if (anim is CABasicAnimation)
//				{
//					var b = (CABasicAnimation)anim;
//					var v = b.To;
//					if (v != null)
//					{
//						var k = b.KeyPath;
//						if (k != null)
//						{
//							mParent.Layer.SetValueForKey(v, new NSString(k));
//							mParent.Layer.RemoveAnimation(k);
//						}
//					}
//				}
//			}
//			else if (anim is CAAnimationGroup)
//			{
//				foreach (var x in ((CAAnimationGroup)anim).Animations)
//				{
//					AnimationStopped(anim: x, finished: true);
//				}
//			}
//		}
//	}


//	public class MaterialTableViewCell : UITableViewCell
//	{

//		#region VARIABLES

//		private Queue<CAShapeLayer> mPulseLayers = new Queue<CAShapeLayer>();

//		#endregion

//		#region PROPERTIES

//		private CAShapeLayer VisualLayer { get; set; } = new CAShapeLayer();

//		public MaterialDelegate Delegate { get; set; }

//		private Queue<CAShapeLayer> PulseLayer
//		{
//			get
//			{
//				return mPulseLayers;
//			}
//			set
//			{
//				mPulseLayers = value;
//			}
//		}

//		public nfloat PulseOpacity { get; set; } = 0.25f;

//		public UIColor PulseColor { get; set; } = MaterialColor.Grey.Base;

//		private PulseAnimation mPulseAnimation = PulseAnimation.AtPointWithBacking;
//		public PulseAnimation PulseAnimation
//		{
//			get
//			{
//				return mPulseAnimation;
//			}
//			set
//			{
//				mPulseAnimation = value;
//				VisualLayer.MasksToBounds = mPulseAnimation != PulseAnimation.CenterRadialBeyondBounds;
//			}
//		}

//		public bool MasksToBounds
//		{
//			get
//			{
//				return Layer.MasksToBounds;
//			}
//			set
//			{
//				Layer.MasksToBounds = value;
//			}
//		}

//		public override UIColor BackgroundColor
//		{
//			get
//			{
//				return base.BackgroundColor;
//			}
//			set
//			{
//				base.BackgroundColor = value;
//				if (BackgroundColor != null)
//				{
//					Layer.BackgroundColor = BackgroundColor.CGColor;
//				}
//			}
//		}

//		public nfloat X
//		{
//			get
//			{
//				return Layer.Frame.X;
//			}
//			set
//			{
//				var frame = Layer.Frame;
//				frame.X = value;
//				Layer.Frame = frame;
//			}
//		}

//		public nfloat Y
//		{
//			get
//			{
//				return Layer.Frame.Y;
//			}
//			set
//			{
//				var frame = Layer.Frame;
//				frame.Y = value;
//				Layer.Frame = frame;
//			}
//		}

//		public nfloat Width
//		{
//			get
//			{
//				return Layer.Frame.Width;
//			}
//			set
//			{
//				var frame = Layer.Frame;
//				frame.Width = value;
//				Layer.Frame = frame;
//			}
//		}

//		public nfloat Height
//		{
//			get
//			{
//				return Layer.Frame.Height;
//			}
//			set
//			{
//				var frame = Layer.Frame;
//				frame.Height = value;
//				Layer.Frame = frame;
//			}
//		}

//		private UIColor mShadowColor;
//		public UIColor ShadowColor
//		{
//			get
//			{
//				return mShadowColor;
//			}
//			set
//			{
//				mShadowColor = value;
//				if (value != null)
//				{
//					Layer.ShadowColor = value.CGColor;
//				}
//			}
//		}

//		public CGSize ShadowOffset
//		{
//			get
//			{
//				return Layer.ShadowOffset;
//			}
//			set
//			{
//				Layer.ShadowOffset = value;
//			}
//		}

//		public float ShadowOpacity
//		{
//			get
//			{
//				return Layer.ShadowOpacity;
//			}
//			set
//			{
//				Layer.ShadowOpacity = value;
//			}
//		}

//		public nfloat ShadowRadius
//		{
//			get
//			{
//				return Layer.ShadowRadius;
//			}
//			set
//			{
//				Layer.ShadowRadius = value;
//			}
//		}

//		public CGPath ShadowPath
//		{
//			get
//			{
//				return Layer.ShadowPath;
//			}
//			set
//			{
//				Layer.ShadowPath = value;
//			}
//		}

//		private bool mShadowPathAutoSizeEnabled = true;
//		public bool ShadowPathAutoSizeEnabled
//		{
//			get
//			{
//				return mShadowPathAutoSizeEnabled;
//			}
//			set
//			{
//				mShadowPathAutoSizeEnabled = value;
//				if (mShadowPathAutoSizeEnabled)
//				{
//					layoutShadowPath();
//				}
//			}
//		}

//		private MaterialDepth mDepth;
//		public MaterialDepth Depth
//		{
//			get
//			{
//				return mDepth;
//			}
//			set
//			{
//				mDepth = value;
//				var depthValue = Convert.MaterialDepthToValue(value);
//				ShadowOffset = depthValue.Offset;
//				ShadowOpacity = depthValue.Opacity;
//				ShadowRadius = depthValue.Radius;
//				layoutShadowPath();
//			}
//		}

//		public MaterialRadius CornerRadiusPreset { get; set; }

//		public nfloat CornerRadius
//		{
//			get
//			{
//				return Layer.CornerRadius;
//			}
//			set
//			{
//				Layer.CornerRadius = value;
//				layoutShadowPath();
//				if (Shape == MaterialShape.Circle)
//				{
//					Shape = MaterialShape.None;
//				}
//			}
//		}

//		private MaterialShape mShape;
//		public MaterialShape Shape
//		{
//			get
//			{
//				return mShape;
//			}
//			set
//			{
//				mShape = value;
//				if (mShape != MaterialShape.None)
//				{
//					var frame = Frame;
//					if (Width < Height)
//					{
//						frame.Width = Height;
//					}
//					else
//					{
//						frame.Height = Width;
//					}
//					Frame = frame;
//					layoutShadowPath();
//				}
//			}
//		}

//		private MaterialBorder mBorderWidthPreset = MaterialBorder.None;
//		public MaterialBorder BorderWidthPreset
//		{
//			get
//			{
//				return mBorderWidthPreset;
//			}
//			set
//			{
//				mBorderWidthPreset = value;
//				BorderWidth = Convert.MaterialBorderToValue(BorderWidthPreset);
//			}
//		}

//		public nfloat BorderWidth
//		{
//			get
//			{
//				return Layer.BorderWidth;
//			}
//			set
//			{
//				Layer.BorderWidth = value;
//			}
//		}

//		public UIColor BorderColor
//		{
//			get
//			{
//				return Layer.BorderColor == null ? null : new UIColor(Layer.BorderColor);
//			}
//			set
//			{
//				if (value != null)
//					Layer.BorderColor = value.CGColor;
//			}
//		}

//		public CGPoint Position
//		{
//			get
//			{
//				return Layer.Position;
//			}
//			set
//			{
//				Layer.Position = value;
//			}
//		}

//		public nfloat ZPosition
//		{
//			get
//			{
//				return Layer.ZPosition;
//			}
//			set
//			{
//				Layer.ZPosition = value;
//			}
//		}

//		#endregion

//		#region CONSTRUCTORS

//		public MaterialTableViewCell(Foundation.NSCoder coder) : base(coder)
//		{
//			prepareView();
//		}

//		public MaterialTableViewCell(UITableViewCellStyle style, string reuseIdentifier) : base(style, reuseIdentifier)
//		{
//			prepareView();
//		}

//		#endregion

//		#region OVERRIDE FUNCTIONS

//		public override void LayoutSublayersOfLayer(CALayer layer)
//		{
//			base.LayoutSublayersOfLayer(layer);
//			if (this.Layer == layer)
//			{
//				layoutShape();
//				layoutVisualLayer();
//			}
//		}

//		public override void LayoutSubviews()
//		{
//			base.LayoutSubviews();
//			layoutShadowPath();
//		}

//		public void Animate(CAAnimation animation)
//		{
//			animation.WeakDelegate = new MaterialTableViewCellAnimationDelegate(this);
//			if (animation is CABasicAnimation)
//			{
//				var a = (CABasicAnimation)animation;
//				a.From = (Layer.PresentationLayer == null ? Layer : Layer.PresentationLayer).ValueForKey(new NSString(a.KeyPath));
//			}
//			if (animation is CAPropertyAnimation)
//			{
//				var a = (CAPropertyAnimation)animation;
//				Layer.AddAnimation(a, a.KeyPath);
//			}
//			else if (animation is CAAnimationGroup)
//			{
//				var a = (CAAnimationGroup)animation;
//				Layer.AddAnimation(a, null);
//			}
//			else if (animation is CATransition)
//			{
//				var a = (CATransition)animation;
//				Layer.AddAnimation(a, CALayer.Transition);
//			}

//		}

//		public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
//		{
//			base.TouchesBegan(touches, evt);
//			UITouch touch = touches.AnyObject as UITouch;
//			MaterialAnimation.pulseExpandAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseOpacity: PulseOpacity, point: Layer.ConvertPointToLayer(point: touch.LocationInView(this), layer: Layer), width: Width, height: Height, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);
//		}

//		public override void TouchesEnded(Foundation.NSSet touches, UIEvent evt)
//		{
//			base.TouchesEnded(touches, evt);
//			MaterialAnimation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);

//		}

//		public override void TouchesCancelled(Foundation.NSSet touches, UIEvent evt)
//		{
//			base.TouchesCancelled(touches, evt);
//			MaterialAnimation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);
//		}

//		#endregion

//		#region FUNCTIONS

//		public virtual void prepareView()
//		{
//			SelectionStyle = UITableViewCellSelectionStyle.None;
//			SeparatorInset = UIEdgeInsets.Zero;
//			ContentScaleFactor = MaterialDevice.Scale;
//			if (ImageView != null)
//			{
//				ImageView.UserInteractionEnabled = false;
//			}
//			if (TextLabel != null)
//			{
//				TextLabel.UserInteractionEnabled = false;
//			}
//			if (DetailTextLabel != null)
//			{
//				DetailTextLabel.UserInteractionEnabled = false;
//			}
//			prepareVisualLayer();
//		}

//		internal void prepareVisualLayer()
//		{
//			VisualLayer.ZPosition = 0;
//			VisualLayer.MasksToBounds = true;
//			Layer.AddSublayer(VisualLayer);
//		}

//		internal void layoutVisualLayer()
//		{
//			VisualLayer.Frame = Bounds;
//			VisualLayer.CornerRadius = CornerRadius;
//		}

//		internal void layoutShape()
//		{
//			if (Shape == MaterialShape.Circle)
//			{
//				var w = Width / 2;
//				if (w != CornerRadius)
//				{
//					CornerRadius = w;
//				}
//			}
//		}

//		internal void layoutShadowPath()
//		{
//			if (ShadowPathAutoSizeEnabled)
//			{
//				if (Depth == MaterialDepth.None)
//				{
//					ShadowPath = null;
//				}
//				else if (ShadowPath == null)
//				{
//					ShadowPath = UIBezierPath.FromRoundedRect(rect: Bounds, cornerRadius: CornerRadius).CGPath;
//				}
//				else
//				{
//					Animate(MaterialAnimation.ShadowPath(UIBezierPath.FromRoundedRect(rect: Bounds, cornerRadius: CornerRadius).CGPath, duration: 0));
//				}
//			}
//		}

//		#endregion
//	}
//}
