using UnityEngine;
using System.Collections;

namespace HueSaturationValueUtils {

	/// <summary>
	/// Represents color in Hue/Saturation/Value Format
	/// Can be cast to Color
	/// </summary>
	public struct ColorHSV {
		public readonly float h,s,v;

		public ColorHSV(float h, float s, float v) {
			this.h = Mathf.Max(0, Mathf.Min (h,1f));
			this.s = Mathf.Max(0, Mathf.Min (s,1f));
			this.v = Mathf.Max(0, Mathf.Min (v,1f));
		}

		//allow casting to color
		public static implicit operator Color(ColorHSV colorHSV)
		{
			return colorHSV.toRGB ();
		}
		
		public Color toRGB () {
			float r, g, b;

			if(s == 0) {
				// Achromatic (grey)
				r = v;
				g = v;
				b = v;
				return new Color(r,g,b);
			}

			float h2 = h * 6;
			int segment = (int)Mathf.Floor (h * 6f);

			float i = Mathf.Floor(h2);
			float f = h2 - i; // factorial part of h
			float p = v * (1f - s);
			float q = v * (1f - s * f);	
			float t = v * (1f - s * (1f - f));


			switch (segment) {
			case 0:
				r = v;
				g = t;
				b = p;
				break;
				
			case 1:
				r = q;
				g = v;
				b = p;
				break;
				
			case 2:
				r = p;
				g = v;
				b = t;
				break;
				
			case 3:
				r = p;
				g = q;
				b = v;
				break;
				
			case 4:
				r = t;
				g = p;
				b = v;
				break;

			case 5:
				r = v;
				g = p;
				b = q;
				break;
			default:
				r=0;
				g=0;
				b=0;
				break;
			}

			return new Color (r, g, b);
		}
	}

	/// <summary>
	/// Adds toHSV function to Color class
	/// </summary>
	public static class ColorExtension {
		/// <summary>
		/// Convert color to ColorHSV.
		/// </summary>
		/// <returns>ColorHSV</returns>
		/// <param name="color">Color.</param>
		public static ColorHSV toHSV ( this Color color ) {

			float h = 0;
			float s = 0;
			float v = 0;
			float r = color.r;
			float g = color.g;
			float b = color.b;

			float minRGB = Mathf.Min(r,Mathf.Min(g,b));
			float maxRGB = Mathf.Max(r,Mathf.Max(g,b));
			
			// Black-gray-white
			if (minRGB==maxRGB) {
				v = minRGB;
				return new ColorHSV(0,0,v);
			}
			
			// Colors other than black-gray-white:
			var d = (r==minRGB) ? g-b : ((b==minRGB) ? r-g : b-r);
			var h2 = (r==minRGB) ? 3 : ((b==minRGB) ? 1 : 5);
			h = (h2 - d/(maxRGB - minRGB))/6f;
			s = (maxRGB - minRGB)/maxRGB;
			v = maxRGB;
			return new ColorHSV(h,s,v);
		}
	}
}
