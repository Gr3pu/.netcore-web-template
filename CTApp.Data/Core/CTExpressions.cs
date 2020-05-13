using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CTApp.Data.Core
{
	class CTExpressions
	{
		public static Expression<Func<E, bool>> EqualOf<E, T>(string property, T constant)
		{
			var n = Expression.Parameter(typeof(E), "n");
			var prop = Expression.Property(n, property);
			var c = Expression.Constant(constant);
			var equal = Expression.Equal(prop, c);
			var lambda = Expression.Lambda<Func<E, bool>>(equal, n);

			return lambda;
		}

		public static Expression<Func<E, bool>> GreaterThan<E, T>(string property, T constant)
		{
			var n = Expression.Parameter(typeof(E), "n");
			var prop = Expression.Property(n, property);
			var c = Expression.Constant(constant);
			var equal = Expression.GreaterThan(prop, c);
			var lambda = Expression.Lambda<Func<E, bool>>(equal, n);

			return lambda;
		}

		public static Expression<Func<E, bool>> LesserThan<E, T>(string property, T constant)
		{
			var n = Expression.Parameter(typeof(E), "n");
			var prop = Expression.Property(n, property);
			var c = Expression.Constant(constant);
			var equal = Expression.LessThan(prop, c);
			var lambda = Expression.Lambda<Func<E, bool>>(equal, n);

			return lambda;
		}
	}
}
