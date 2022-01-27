﻿using System.Collections;

namespace AquaSharp {
    public class CropData {
        private readonly Hashtable _properties = new();

        public T? getProperty<T>(CropProperty<T> key) where T : class {
            return _properties[key] as T;
        }

        public void setProperty<T>(CropProperty<T> key, T? value) where T : class {
            _properties[key] = value;
        }
    }
}