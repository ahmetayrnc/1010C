using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _1010C.Scripts.Misc
{
    public abstract class Enumeration : IComparable
    {
        protected Enumeration()
        {
        }

        protected Enumeration(int value, string name)
        {
            Value = value;
            Name = name;
        }

        private int Value { get; }
        private string Name { get; }

        public override string ToString()
        {
            return Name;
        }

        private static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue))
            {
                return false;
            }

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool TryParse<T>(string name, out T result) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(item => item.Name == name);
            result = matchingItem;
            return matchingItem != null;
        }

        public static T FromValue<T>(int value) where T : Enumeration
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Value == value);
            return matchingItem;
        }

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = $"'{value}' is not a valid {description} in {typeof(T)}";
                throw new ApplicationException(message);
            }

            return matchingItem;
        }

        public int CompareTo(object other)
        {
            return Value.CompareTo(((Enumeration) other).Value);
        }
    }
}
