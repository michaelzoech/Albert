using System;
using System.Collections;
using System.Collections.Generic;

public static class Conditions {

    public static void Assert(bool assert, string message) {
        if (!assert) {
            throw new Exception(message);
        }
    }

    public static void NotNull<T>(T obj) {
        if (obj == null) {
            throw new Exception("Expected instance of type " + typeof(T).FullName + ", but was null");
        }
    }
}