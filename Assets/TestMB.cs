using System;
using System.Collections.Generic;
using UnityEngine;

class TestMB : MonoBehaviour
{
    [SerializeField] TestStruct testStruct;
    [SerializeField] TestStruct[] TestStructs;
    [SerializeField] List<TestStruct> testStructs2;
}

[Serializable]
struct TestStruct 
{
    public Vector3 position;
    public Vector3 rotation;
    public float scale;
}
