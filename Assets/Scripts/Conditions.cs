using System;
using System.Collections;
using System.Collections.Generic;

public static class Conditions {

    public static void Assert(bool assert, string message) {
        if (!assert) {
            throw new Exception(message);
        }
    }
}