using System;
using Engine.Plugins.CoherentNoise.Scripts.Generation.Combination;
using Engine.Plugins.CoherentNoise.Scripts.Generation.Displacement;
using Engine.Plugins.CoherentNoise.Scripts.Generation.Modification;
using UnityEngine;

namespace Engine.Plugins.CoherentNoise
{
	/// <summary>
	/// This class defines a number of useful extension methods for <see cref="Generator"/> class, that apply common noise transformations
	/// </summary>
	public static class NoiseEx
	{
		///<summary>
		/// Stretch/squeeze noise generator (<see cref="Scripts.Generation.Displacement.Scale"/>)
		///</summary>
		///<param name="source">Source noise</param>
		///<param name="x">Squeeze in X direction</param>
		///<param name="y">Squeeze in Y direction</param>
		///<param name="z">Squeeze in Z direction</param>
		///<returns></returns>
		public static Generator Scale(this Generator source, float x, float y, float z)
		{
			return new Scale(source, x, y, z);
		}

		///<summary>
		/// Translate (move) noise <see cref="Scripts.Generation.Displacement.Translate"/>
		///</summary>
		///<param name="source">Source noise</param>
		///<param name="x">Distance in X direction</param>
		///<param name="y">Distance in Y direction</param>
		///<param name="z">Distance in Z direction</param>
		///<returns></returns>
		public static Generator Translate(this Generator source, float x, float y, float z)
		{
			return new Translate(source, x, y, z);
		}

		///<summary>
		/// Roate noise (<see cref="Scripts.Generation.Displacement.Rotate"/>)
		///</summary>
		///<param name="source">Noise source</param>
		///<param name="x">Angle around X axis</param>
		///<param name="y">Angle around Y axis</param>
		///<param name="z">Angle around Z axis</param>
		///<returns></returns>
		public static Generator Rotate(this Generator source, float x, float y, float z)
		{
			return new Rotate(source, x, y, z);
		}

		///<summary>
		/// Apply turnbulence transform to noise (<see cref="Scripts.Generation.Displacement.Turbulence"/>)
		///</summary>
		///<param name="source">Noise source</param>
		///<param name="frequency">Turbulence base frequency</param>
		///<param name="power">Turbulence power</param>
		///<param name="seed">Turbulence seed</param>
		///<returns></returns>
		public static Generator Turbulence(this Generator source, float frequency, float power, int seed)
		{
			return new Turbulence(source, seed)
			{
				Frequency = frequency,
				Power = power,
				OctaveCount = 6
			};
		}

		///<summary>
		/// Apply turnbulence transform to noise (<see cref="Scripts.Generation.Displacement.Turbulence"/>) with random seed
		///</summary>
		///<param name="source">Noise source</param>
		///<param name="frequency">Turbulence base frequency</param>
		///<param name="power">Turbulence power</param>
		///<returns></returns>
		public static Generator Turbulence(this Generator source, float frequency, float power)
		{
			return new Turbulence(source, Guid.NewGuid().GetHashCode())
			{
				Frequency = frequency,
				Power = power,
				OctaveCount = 6
			};
		}

		///<summary>
		/// Blend two noise generators using third one as weight
		///</summary>
		///<param name="source">Source noise</param>
		///<param name="other">Noise to blend</param>
		///<param name="weight">Blend weight</param>
		///<returns></returns>
		public static Generator Blend(this Generator source, Generator other, Generator weight)
		{
			return new Blend(source, other, weight);
		}

		///<summary>
		/// Apply modification function to noise
		///</summary>
		///<param name="source">Source noise</param>
		///<param name="modifier">Function to apply</param>
		///<returns></returns>
		public static Generator Modify(this Generator source, Func<float, float> modifier)
		{
			return new Modify(source, modifier);
		}

		///<summary>
		/// Multiply noise by AnimationCurve value
		///</summary>
		///<param name="source">Source noise</param>
		///<param name="curve">Curve</param>
		///<returns></returns>
		public static Generator Curve(this Generator source, AnimationCurve curve)
		{
			return new Curve(source, curve);
		}

		///<summary>
		/// Binarize noise 
		///</summary>
		///<param name="source">Source noise</param>
		///<param name="treshold">Treshold value</param>
		///<returns></returns>
		public static Generator Binarize(this Generator source, float treshold)
		{
			return new Binarize(source, treshold);
		}

        /// <summary>
        /// Apply bias to noise
        /// </summary>
        /// <param name="source">Source noise</param>
        /// <param name="b">Bias value</param>
        /// <returns></returns>
        public static Generator Bias(this Generator source, float b)
        {
            return new Bias(source, b);
        }

        /// <summary>
        /// Apply gain to noise
        /// </summary>
        /// <param name="source">Source noise</param>
        /// <param name="g">Gain value</param>
        /// <returns></returns>
        public static Generator Gain(this Generator source, float g)
        {
            return new Gain(source, g);
        }

        ///<summary>
		/// Apply a linear transform to noise. The same as <code>noise.Modify(f=>a*f+b)</code>
		///</summary>
		///<param name="source">Source noise</param>
		///<param name="a">Scale value</param>
		///<param name="b">Shift value</param>
		///<returns></returns>
		public static Generator ScaleShift(this Generator source, float a, float b)
		{
			return new Modify(source, f => a*f + b);
		}
	}
}