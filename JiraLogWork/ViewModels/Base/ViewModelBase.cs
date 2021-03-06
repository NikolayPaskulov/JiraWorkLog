﻿using JiraLogWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace JiraLogWork.ViewModels
{
	public abstract class ViewModelBase : IViewModel
	{
		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Called when [property changed].
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Called when [property changed].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="selectorExpression">The selector expression.</param>
		/// <exception cref="System.ArgumentNullException">selectorExpression</exception>
		/// <exception cref="System.ArgumentException">The body must be a member expression</exception>
		protected virtual void OnPropertyChanged<T>(Expression<Func<T>> selectorExpression)
		{
			if (selectorExpression == null)
				throw new ArgumentNullException("selectorExpression");
			var body = selectorExpression.Body as MemberExpression;
			if (body == null)
				throw new ArgumentException("The body must be a member expression");
			OnPropertyChanged(body.Member.Name);
		}

		/// <summary>
		/// Sets the field.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="field">The field.</param>
		/// <param name="value">The value.</param>
		/// <param name="selectorExpression">The selector expression.</param>
		/// <returns></returns>
		protected bool SetField<T>(ref T field, T value, Expression<Func<T>> selectorExpression)
		{
			if (EqualityComparer<T>.Default.Equals(field, value)) return false;
			field = value;
			OnPropertyChanged(selectorExpression);
			return true;
		}
	}
}
