namespace MulticastDelegateExtensions
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public static class DelegateExtensions
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "This function is designed to allow all delegates in a list to be invoked. It rethrows any exception afterwards.")]
		private static IEnumerable<object> SafeInvoke(this Delegate del, params object[] args)
		{
			var exceptions = new List<Exception>();
			var returnValues = new List<object>();

			foreach (var d in del.GetInvocationList())
			{
				try
				{
					returnValues.Add(d.Method.Invoke(d.Target, args));
				}
				catch (Exception e)
				{
					exceptions.Add(e);
				}
			}

			if (exceptions.Any())
			{
				throw new AggregateException("Multicast delegate invocation through an exception", exceptions);
			}

			return returnValues;
		}

		private static IEnumerable<object> InvokeAllDelegates(this IEnumerable<Delegate> delegates, params object[] args) => Delegate.Combine(delegates.ToArray()).SafeInvoke(args);

		private static IEnumerable<T> InvokeAllDelegates<T>(this IEnumerable<Delegate> delegates, params object[] args) => delegates.InvokeAllDelegates(args).Select(item => (T)item);

		public static void InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IEnumerable<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16) => actions.InvokeAllDelegates(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		public static void InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IEnumerable<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15) => actions.InvokeAllDelegates(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		public static void InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IEnumerable<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14) => actions.InvokeAllDelegates(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		public static void InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IEnumerable<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13) => actions.InvokeAllDelegates(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		public static void InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IEnumerable<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12) => actions.InvokeAllDelegates(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t12);
		public static void InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IEnumerable<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11) => actions.InvokeAllDelegates(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		public static void InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IEnumerable<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => actions.InvokeAllDelegates(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		public static void InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEnumerable<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => actions.InvokeAllDelegates(t1, t2, t3, t4, t5, t6, t7, t8, t9);
		public static void InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8>(this IEnumerable<Action<T1, T2, T3, T4, T5, T6, T7, T8>> actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => actions.InvokeAllDelegates(t1, t2, t3, t4, t5, t6, t7, t8);
		public static void InvokeAll<T1, T2, T3, T4, T5, T6, T7>(this IEnumerable<Action<T1, T2, T3, T4, T5, T6, T7>> actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => actions.InvokeAllDelegates(t1, t2, t3, t4, t5, t6, t7);
		public static void InvokeAll<T1, T2, T3, T4, T5, T6>(this IEnumerable<Action<T1, T2, T3, T4, T5, T6>> actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => actions.InvokeAllDelegates(t1, t2, t3, t4, t5, t6);
		public static void InvokeAll<T1, T2, T3, T4, T5>(this IEnumerable<Action<T1, T2, T3, T4, T5>> actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => actions.InvokeAllDelegates(t1, t2, t3, t4, t5);
		public static void InvokeAll<T1, T2, T3, T4>(this IEnumerable<Action<T1, T2, T3, T4>> actions, T1 t1, T2 t2, T3 t3, T4 t4) => actions.InvokeAllDelegates(t1, t2, t3, t4);
		public static void InvokeAll<T1, T2, T3>(this IEnumerable<Action<T1, T2, T3>> actions, T1 t1, T2 t2, T3 t3) => actions.InvokeAllDelegates(t1, t2, t3);
		public static void InvokeAll<T1, T2>(this IEnumerable<Action<T1, T2>> actions, T1 t1, T2 t2) => actions.InvokeAllDelegates(t1, t2);
		public static void InvokeAll<T>(this IEnumerable<Action<T>> actions, T t) => actions.InvokeAllDelegates(t);
		public static void InvokeAll(this IEnumerable<Action> actions) => actions.InvokeAllDelegates();


		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(this IEnumerable<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this IEnumerable<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this IEnumerable<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this IEnumerable<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this IEnumerable<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t12);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this IEnumerable<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this IEnumerable<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this IEnumerable<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4, t5, t6, t7, t8, t9);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this IEnumerable<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4, t5, t6, t7, t8);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, T7, TResult>(this IEnumerable<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4, t5, t6, t7);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, T6, TResult>(this IEnumerable<Func<T1, T2, T3, T4, T5, T6, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4, t5, t6);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, T5, TResult>(this IEnumerable<Func<T1, T2, T3, T4, T5, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4, t5);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, T4, TResult>(this IEnumerable<Func<T1, T2, T3, T4, TResult>> functions, T1 t1, T2 t2, T3 t3, T4 t4) => functions.InvokeAllDelegates<TResult>(t1, t2, t3, t4);
		public static IEnumerable<TResult> InvokeAll<T1, T2, T3, TResult>(this IEnumerable<Func<T1, T2, T3, TResult>> functions, T1 t1, T2 t2, T3 t3) => functions.InvokeAllDelegates<TResult>(t1, t2, t3);
		public static IEnumerable<TResult> InvokeAll<T1, T2, TResult>(this IEnumerable<Func<T1, T2, TResult>> functions, T1 t1, T2 t2) => functions.InvokeAllDelegates<TResult>(t1, t2);
		public static IEnumerable<TResult> InvokeAll<T, TResult>(this IEnumerable<Func<T, TResult>> functions, T t) => functions.InvokeAllDelegates<TResult>(t);
		public static IEnumerable<TResult> InvokeAll<TResult>(this IEnumerable<Func<TResult>> functions) => functions.InvokeAllDelegates<TResult>();

		public static void InvokeAll(this EventHandler eventHandler, object sender, EventArgs eventArgs) => eventHandler?.SafeInvoke(sender, eventArgs);
		public static void InvokeAll<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs eventArgs) where TEventArgs : EventArgs => eventHandler?.SafeInvoke(sender, eventArgs);

		public static IEnumerable<bool> InvokeAll<T>(this IEnumerable<Predicate<T>> predicates, T t) => predicates.InvokeAllDelegates<bool>(t);
	}
}
