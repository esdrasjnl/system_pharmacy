#define ICALL_TABLE_corlib 1

static int corlib_icall_indexes [] = {
240,
252,
253,
254,
255,
256,
257,
258,
259,
260,
263,
264,
265,
438,
439,
440,
469,
470,
471,
491,
492,
493,
494,
611,
612,
613,
616,
658,
659,
660,
663,
665,
667,
669,
674,
682,
683,
684,
685,
686,
687,
688,
689,
690,
691,
692,
693,
694,
695,
696,
697,
698,
700,
701,
702,
703,
704,
705,
706,
798,
799,
800,
801,
802,
803,
804,
805,
806,
807,
808,
809,
810,
811,
812,
813,
814,
816,
817,
818,
819,
820,
821,
822,
889,
890,
958,
965,
968,
970,
975,
976,
978,
979,
983,
984,
986,
988,
989,
992,
993,
994,
997,
999,
1002,
1004,
1006,
1015,
1083,
1085,
1087,
1097,
1098,
1099,
1100,
1102,
1109,
1110,
1111,
1112,
1113,
1121,
1122,
1123,
1127,
1128,
1130,
1134,
1135,
1136,
1420,
1611,
1612,
9825,
9826,
9828,
9829,
9830,
9831,
9832,
9834,
9836,
9838,
9839,
9850,
9852,
9859,
9861,
9863,
9865,
9917,
9918,
9920,
9921,
9922,
9923,
9924,
9926,
9928,
11068,
11072,
11074,
11075,
11076,
11077,
11340,
11341,
11342,
11343,
11361,
11362,
11363,
11365,
11408,
11494,
11496,
11498,
11508,
11509,
11510,
11511,
11512,
11972,
11973,
11978,
11979,
12013,
12033,
12040,
12047,
12058,
12062,
12088,
12169,
12171,
12182,
12184,
12185,
12186,
12193,
12208,
12228,
12229,
12237,
12239,
12246,
12247,
12250,
12252,
12257,
12263,
12264,
12271,
12273,
12285,
12288,
12289,
12290,
12301,
12310,
12316,
12317,
12318,
12320,
12321,
12338,
12340,
12354,
12376,
12377,
12402,
12407,
12437,
12438,
12984,
12998,
13093,
13094,
13309,
13310,
13317,
13318,
13319,
13325,
13423,
13988,
13989,
14569,
14570,
14571,
14576,
14586,
15562,
15583,
15585,
15587,
};
void ves_icall_System_Array_InternalCreate (int,int,int,int,int);
int ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal (int);
int ves_icall_System_Array_IsValueOfElementTypeInternal (int,int);
int ves_icall_System_Array_CanChangePrimitive (int,int,int);
int ves_icall_System_Array_FastCopy (int,int,int,int,int);
int ves_icall_System_Array_GetLengthInternal_raw (int,int,int);
int ves_icall_System_Array_GetLowerBoundInternal_raw (int,int,int);
void ves_icall_System_Array_GetGenericValue_icall (int,int,int);
void ves_icall_System_Array_GetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_SetGenericValue_icall (int,int,int);
void ves_icall_System_Array_SetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_InitializeInternal_raw (int,int);
void ves_icall_System_Array_SetValueRelaxedImpl_raw (int,int,int,int);
void ves_icall_System_Runtime_RuntimeImports_ZeroMemory (int,int);
void ves_icall_System_Runtime_RuntimeImports_Memmove (int,int,int);
void ves_icall_System_Buffer_BulkMoveWithWriteBarrier (int,int,int,int);
int ves_icall_System_Delegate_AllocDelegateLike_internal_raw (int,int);
int ves_icall_System_Delegate_CreateDelegate_internal_raw (int,int,int,int,int);
int ves_icall_System_Delegate_GetVirtualMethod_internal_raw (int,int);
void ves_icall_System_Enum_GetEnumValuesAndNames_raw (int,int,int,int);
void ves_icall_System_Enum_InternalBoxEnum_raw (int,int,int64_t,int);
int ves_icall_System_Enum_InternalGetCorElementType (int);
void ves_icall_System_Enum_InternalGetUnderlyingType_raw (int,int,int);
int ves_icall_System_Environment_get_ProcessorCount ();
int ves_icall_System_Environment_get_TickCount ();
int64_t ves_icall_System_Environment_get_TickCount64 ();
void ves_icall_System_Environment_FailFast_raw (int,int,int,int);
int ves_icall_System_GC_GetCollectionCount (int);
void ves_icall_System_GC_register_ephemeron_array_raw (int,int);
int ves_icall_System_GC_get_ephemeron_tombstone_raw (int);
void ves_icall_System_GC_SuppressFinalize_raw (int,int);
void ves_icall_System_GC_ReRegisterForFinalize_raw (int,int);
void ves_icall_System_GC_GetGCMemoryInfo (int,int,int,int,int,int);
int ves_icall_System_GC_AllocPinnedArray_raw (int,int,int);
int ves_icall_System_Object_MemberwiseClone_raw (int,int);
double ves_icall_System_Math_Acos (double);
double ves_icall_System_Math_Acosh (double);
double ves_icall_System_Math_Asin (double);
double ves_icall_System_Math_Asinh (double);
double ves_icall_System_Math_Atan (double);
double ves_icall_System_Math_Atan2 (double,double);
double ves_icall_System_Math_Atanh (double);
double ves_icall_System_Math_Cbrt (double);
double ves_icall_System_Math_Ceiling (double);
double ves_icall_System_Math_Cos (double);
double ves_icall_System_Math_Cosh (double);
double ves_icall_System_Math_Exp (double);
double ves_icall_System_Math_Floor (double);
double ves_icall_System_Math_Log (double);
double ves_icall_System_Math_Log10 (double);
double ves_icall_System_Math_Pow (double,double);
double ves_icall_System_Math_Sin (double);
double ves_icall_System_Math_Sinh (double);
double ves_icall_System_Math_Sqrt (double);
double ves_icall_System_Math_Tan (double);
double ves_icall_System_Math_Tanh (double);
double ves_icall_System_Math_FusedMultiplyAdd (double,double,double);
double ves_icall_System_Math_Log2 (double);
double ves_icall_System_Math_ModF (double,int);
float ves_icall_System_MathF_Acos (float);
float ves_icall_System_MathF_Acosh (float);
float ves_icall_System_MathF_Asin (float);
float ves_icall_System_MathF_Asinh (float);
float ves_icall_System_MathF_Atan (float);
float ves_icall_System_MathF_Atan2 (float,float);
float ves_icall_System_MathF_Atanh (float);
float ves_icall_System_MathF_Cbrt (float);
float ves_icall_System_MathF_Ceiling (float);
float ves_icall_System_MathF_Cos (float);
float ves_icall_System_MathF_Cosh (float);
float ves_icall_System_MathF_Exp (float);
float ves_icall_System_MathF_Floor (float);
float ves_icall_System_MathF_Log (float);
float ves_icall_System_MathF_Log10 (float);
float ves_icall_System_MathF_Pow (float,float);
float ves_icall_System_MathF_Sin (float);
float ves_icall_System_MathF_Sinh (float);
float ves_icall_System_MathF_Sqrt (float);
float ves_icall_System_MathF_Tan (float);
float ves_icall_System_MathF_Tanh (float);
float ves_icall_System_MathF_FusedMultiplyAdd (float,float,float);
float ves_icall_System_MathF_Log2 (float);
float ves_icall_System_MathF_ModF (float,int);
void ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw (int,int,int);
void ves_icall_RuntimeMethodHandle_ReboxToNullable_raw (int,int,int,int);
int ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw (int,int,int);
void ves_icall_RuntimeType_make_array_type_raw (int,int,int,int);
void ves_icall_RuntimeType_make_byref_type_raw (int,int,int);
void ves_icall_RuntimeType_make_pointer_type_raw (int,int,int);
void ves_icall_RuntimeType_MakeGenericType_raw (int,int,int,int);
int ves_icall_RuntimeType_GetMethodsByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetPropertiesByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetConstructors_native_raw (int,int,int);
int ves_icall_System_RuntimeType_CreateInstanceInternal_raw (int,int);
void ves_icall_System_RuntimeType_AllocateValueType_raw (int,int,int,int);
void ves_icall_RuntimeType_GetDeclaringMethod_raw (int,int,int);
void ves_icall_System_RuntimeType_getFullName_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetGenericArgumentsInternal_raw (int,int,int,int);
int ves_icall_RuntimeType_GetGenericParameterPosition (int);
int ves_icall_RuntimeType_GetEvents_native_raw (int,int,int,int);
int ves_icall_RuntimeType_GetFields_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetInterfaces_raw (int,int,int);
int ves_icall_RuntimeType_GetNestedTypes_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetDeclaringType_raw (int,int,int);
void ves_icall_RuntimeType_GetName_raw (int,int,int);
void ves_icall_RuntimeType_GetNamespace_raw (int,int,int);
int ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetAttributes (int);
int ves_icall_RuntimeTypeHandle_GetMetadataToken_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_GetCorElementType (int);
int ves_icall_RuntimeTypeHandle_HasInstantiation (int);
int ves_icall_RuntimeTypeHandle_IsComObject_raw (int,int);
int ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_HasReferences_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetArrayRank_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetAssembly_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetElementType_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetModule_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetBaseType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition (int);
int ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw (int,int);
int ves_icall_RuntimeTypeHandle_is_subclass_of_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsByRefLike_raw (int,int);
void ves_icall_System_RuntimeTypeHandle_internal_from_name_raw (int,int,int,int,int,int);
int ves_icall_System_String_FastAllocateString_raw (int,int);
int ves_icall_System_String_InternalIsInterned_raw (int,int);
int ves_icall_System_String_InternalIntern_raw (int,int);
int ves_icall_System_Type_internal_from_handle_raw (int,int);
int ves_icall_System_ValueType_InternalGetHashCode_raw (int,int,int);
int ves_icall_System_ValueType_Equals_raw (int,int,int,int);
int ves_icall_System_Threading_Interlocked_CompareExchange_Int (int,int,int);
void ves_icall_System_Threading_Interlocked_CompareExchange_Object (int,int,int,int);
int ves_icall_System_Threading_Interlocked_Decrement_Int (int);
int ves_icall_System_Threading_Interlocked_Increment_Int (int);
int64_t ves_icall_System_Threading_Interlocked_Increment_Long (int);
int ves_icall_System_Threading_Interlocked_Exchange_Int (int,int);
void ves_icall_System_Threading_Interlocked_Exchange_Object (int,int,int);
int64_t ves_icall_System_Threading_Interlocked_CompareExchange_Long (int,int64_t,int64_t);
int64_t ves_icall_System_Threading_Interlocked_Exchange_Long (int,int64_t);
int ves_icall_System_Threading_Interlocked_Add_Int (int,int);
int64_t ves_icall_System_Threading_Interlocked_Add_Long (int,int64_t);
void ves_icall_System_Threading_Monitor_Monitor_Enter_raw (int,int);
void mono_monitor_exit_icall_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw (int,int);
int ves_icall_System_Threading_Monitor_Monitor_wait_raw (int,int,int,int);
void ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw (int,int,int,int,int);
void ves_icall_System_Threading_Thread_InitInternal_raw (int,int);
int ves_icall_System_Threading_Thread_GetCurrentThread ();
void ves_icall_System_Threading_InternalThread_Thread_free_internal_raw (int,int);
int ves_icall_System_Threading_Thread_GetState_raw (int,int);
void ves_icall_System_Threading_Thread_SetState_raw (int,int,int);
void ves_icall_System_Threading_Thread_ClrState_raw (int,int,int);
void ves_icall_System_Threading_Thread_SetName_icall_raw (int,int,int,int);
int ves_icall_System_Threading_Thread_YieldInternal ();
void ves_icall_System_Threading_Thread_SetPriority_raw (int,int,int);
void ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw (int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw (int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw (int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw (int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw (int);
int ves_icall_System_GCHandle_InternalAlloc_raw (int,int,int);
void ves_icall_System_GCHandle_InternalFree_raw (int,int);
int ves_icall_System_GCHandle_InternalGet_raw (int,int);
void ves_icall_System_GCHandle_InternalSet_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError ();
void ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError (int);
void ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw (int,int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_SizeOfHelper_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalTryGetHashCode_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw (int,int);
void ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw (int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw (int,int,int,int);
void ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_RunClassConstructor_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack ();
int ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw (int,int);
int ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw (int);
int ves_icall_System_Reflection_Assembly_InternalLoad_raw (int,int,int,int);
int ves_icall_System_Reflection_Assembly_InternalGetType_raw (int,int,int,int,int,int);
int ves_icall_System_Reflection_AssemblyName_GetNativeName (int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw (int,int,int,int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw (int,int);
int ves_icall_MonoCustomAttrs_IsDefinedInternal_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw (int,int);
int ves_icall_System_Reflection_LoaderAllocatorScout_Destroy (int);
void ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw (int,int,int,int);
int ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw (int,int,int,int,int);
void ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw (int,int,int,int,int,int,int);
void ves_icall_RuntimeEventInfo_get_event_info_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_ResolveType_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetParentType_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_GetFieldOffset_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetValueInternal_raw (int,int,int);
void ves_icall_RuntimeFieldInfo_SetValueInternal_raw (int,int,int,int);
int ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw (int,int);
int ves_icall_reflection_get_token_raw (int,int);
void ves_icall_get_method_info_raw (int,int,int);
int ves_icall_get_method_attributes (int);
int ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw (int,int,int);
int ves_icall_System_MonoMethodInfo_get_retval_marshal_raw (int,int);
int ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw (int,int,int,int);
int ves_icall_RuntimeMethodInfo_get_name_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_base_method_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
void ves_icall_RuntimeMethodInfo_GetPInvoke_raw (int,int,int,int,int);
int ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw (int,int,int);
int ves_icall_RuntimeMethodInfo_GetGenericArguments_raw (int,int);
int ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw (int,int);
void ves_icall_InvokeClassConstructor_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
void ves_icall_System_Reflection_RuntimeModule_GetGuidInternal_raw (int,int,int);
int ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw (int,int,int,int,int,int);
int ves_icall_RuntimeParameterInfo_GetTypeModifiers_raw (int,int,int,int,int,int);
void ves_icall_RuntimePropertyInfo_get_property_info_raw (int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_CustomAttributeBuilder_GetBlob_raw (int,int,int,int,int,int,int,int);
void ves_icall_DynamicMethod_create_dynamic_method_raw (int,int,int,int,int);
void ves_icall_AssemblyBuilder_basic_init_raw (int,int);
void ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw (int,int);
void ves_icall_ModuleBuilder_basic_init_raw (int,int);
void ves_icall_ModuleBuilder_set_wrappers_type_raw (int,int,int);
int ves_icall_ModuleBuilder_getUSIndex_raw (int,int,int);
int ves_icall_ModuleBuilder_getToken_raw (int,int,int,int);
int ves_icall_ModuleBuilder_getMethodToken_raw (int,int,int,int);
void ves_icall_ModuleBuilder_RegisterToken_raw (int,int,int,int);
int ves_icall_TypeBuilder_create_runtime_class_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw (int,int);
int ves_icall_System_Diagnostics_Debugger_IsAttached_internal ();
int ves_icall_System_Diagnostics_Debugger_IsLogging ();
void ves_icall_System_Diagnostics_Debugger_Log (int,int,int);
int ves_icall_System_Diagnostics_StackFrame_GetFrameInfo (int,int,int,int,int,int,int,int);
void ves_icall_System_Diagnostics_StackTrace_GetTrace (int,int,int,int);
int ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass (int);
void ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree (int);
int ves_icall_Mono_SafeStringMarshal_StringToUtf8 (int);
void ves_icall_Mono_SafeStringMarshal_GFree (int);
static void *corlib_icall_funcs [] = {
// token 240,
ves_icall_System_Array_InternalCreate,
// token 252,
ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal,
// token 253,
ves_icall_System_Array_IsValueOfElementTypeInternal,
// token 254,
ves_icall_System_Array_CanChangePrimitive,
// token 255,
ves_icall_System_Array_FastCopy,
// token 256,
ves_icall_System_Array_GetLengthInternal_raw,
// token 257,
ves_icall_System_Array_GetLowerBoundInternal_raw,
// token 258,
ves_icall_System_Array_GetGenericValue_icall,
// token 259,
ves_icall_System_Array_GetValueImpl_raw,
// token 260,
ves_icall_System_Array_SetGenericValue_icall,
// token 263,
ves_icall_System_Array_SetValueImpl_raw,
// token 264,
ves_icall_System_Array_InitializeInternal_raw,
// token 265,
ves_icall_System_Array_SetValueRelaxedImpl_raw,
// token 438,
ves_icall_System_Runtime_RuntimeImports_ZeroMemory,
// token 439,
ves_icall_System_Runtime_RuntimeImports_Memmove,
// token 440,
ves_icall_System_Buffer_BulkMoveWithWriteBarrier,
// token 469,
ves_icall_System_Delegate_AllocDelegateLike_internal_raw,
// token 470,
ves_icall_System_Delegate_CreateDelegate_internal_raw,
// token 471,
ves_icall_System_Delegate_GetVirtualMethod_internal_raw,
// token 491,
ves_icall_System_Enum_GetEnumValuesAndNames_raw,
// token 492,
ves_icall_System_Enum_InternalBoxEnum_raw,
// token 493,
ves_icall_System_Enum_InternalGetCorElementType,
// token 494,
ves_icall_System_Enum_InternalGetUnderlyingType_raw,
// token 611,
ves_icall_System_Environment_get_ProcessorCount,
// token 612,
ves_icall_System_Environment_get_TickCount,
// token 613,
ves_icall_System_Environment_get_TickCount64,
// token 616,
ves_icall_System_Environment_FailFast_raw,
// token 658,
ves_icall_System_GC_GetCollectionCount,
// token 659,
ves_icall_System_GC_register_ephemeron_array_raw,
// token 660,
ves_icall_System_GC_get_ephemeron_tombstone_raw,
// token 663,
ves_icall_System_GC_SuppressFinalize_raw,
// token 665,
ves_icall_System_GC_ReRegisterForFinalize_raw,
// token 667,
ves_icall_System_GC_GetGCMemoryInfo,
// token 669,
ves_icall_System_GC_AllocPinnedArray_raw,
// token 674,
ves_icall_System_Object_MemberwiseClone_raw,
// token 682,
ves_icall_System_Math_Acos,
// token 683,
ves_icall_System_Math_Acosh,
// token 684,
ves_icall_System_Math_Asin,
// token 685,
ves_icall_System_Math_Asinh,
// token 686,
ves_icall_System_Math_Atan,
// token 687,
ves_icall_System_Math_Atan2,
// token 688,
ves_icall_System_Math_Atanh,
// token 689,
ves_icall_System_Math_Cbrt,
// token 690,
ves_icall_System_Math_Ceiling,
// token 691,
ves_icall_System_Math_Cos,
// token 692,
ves_icall_System_Math_Cosh,
// token 693,
ves_icall_System_Math_Exp,
// token 694,
ves_icall_System_Math_Floor,
// token 695,
ves_icall_System_Math_Log,
// token 696,
ves_icall_System_Math_Log10,
// token 697,
ves_icall_System_Math_Pow,
// token 698,
ves_icall_System_Math_Sin,
// token 700,
ves_icall_System_Math_Sinh,
// token 701,
ves_icall_System_Math_Sqrt,
// token 702,
ves_icall_System_Math_Tan,
// token 703,
ves_icall_System_Math_Tanh,
// token 704,
ves_icall_System_Math_FusedMultiplyAdd,
// token 705,
ves_icall_System_Math_Log2,
// token 706,
ves_icall_System_Math_ModF,
// token 798,
ves_icall_System_MathF_Acos,
// token 799,
ves_icall_System_MathF_Acosh,
// token 800,
ves_icall_System_MathF_Asin,
// token 801,
ves_icall_System_MathF_Asinh,
// token 802,
ves_icall_System_MathF_Atan,
// token 803,
ves_icall_System_MathF_Atan2,
// token 804,
ves_icall_System_MathF_Atanh,
// token 805,
ves_icall_System_MathF_Cbrt,
// token 806,
ves_icall_System_MathF_Ceiling,
// token 807,
ves_icall_System_MathF_Cos,
// token 808,
ves_icall_System_MathF_Cosh,
// token 809,
ves_icall_System_MathF_Exp,
// token 810,
ves_icall_System_MathF_Floor,
// token 811,
ves_icall_System_MathF_Log,
// token 812,
ves_icall_System_MathF_Log10,
// token 813,
ves_icall_System_MathF_Pow,
// token 814,
ves_icall_System_MathF_Sin,
// token 816,
ves_icall_System_MathF_Sinh,
// token 817,
ves_icall_System_MathF_Sqrt,
// token 818,
ves_icall_System_MathF_Tan,
// token 819,
ves_icall_System_MathF_Tanh,
// token 820,
ves_icall_System_MathF_FusedMultiplyAdd,
// token 821,
ves_icall_System_MathF_Log2,
// token 822,
ves_icall_System_MathF_ModF,
// token 889,
ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw,
// token 890,
ves_icall_RuntimeMethodHandle_ReboxToNullable_raw,
// token 958,
ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw,
// token 965,
ves_icall_RuntimeType_make_array_type_raw,
// token 968,
ves_icall_RuntimeType_make_byref_type_raw,
// token 970,
ves_icall_RuntimeType_make_pointer_type_raw,
// token 975,
ves_icall_RuntimeType_MakeGenericType_raw,
// token 976,
ves_icall_RuntimeType_GetMethodsByName_native_raw,
// token 978,
ves_icall_RuntimeType_GetPropertiesByName_native_raw,
// token 979,
ves_icall_RuntimeType_GetConstructors_native_raw,
// token 983,
ves_icall_System_RuntimeType_CreateInstanceInternal_raw,
// token 984,
ves_icall_System_RuntimeType_AllocateValueType_raw,
// token 986,
ves_icall_RuntimeType_GetDeclaringMethod_raw,
// token 988,
ves_icall_System_RuntimeType_getFullName_raw,
// token 989,
ves_icall_RuntimeType_GetGenericArgumentsInternal_raw,
// token 992,
ves_icall_RuntimeType_GetGenericParameterPosition,
// token 993,
ves_icall_RuntimeType_GetEvents_native_raw,
// token 994,
ves_icall_RuntimeType_GetFields_native_raw,
// token 997,
ves_icall_RuntimeType_GetInterfaces_raw,
// token 999,
ves_icall_RuntimeType_GetNestedTypes_native_raw,
// token 1002,
ves_icall_RuntimeType_GetDeclaringType_raw,
// token 1004,
ves_icall_RuntimeType_GetName_raw,
// token 1006,
ves_icall_RuntimeType_GetNamespace_raw,
// token 1015,
ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw,
// token 1083,
ves_icall_RuntimeTypeHandle_GetAttributes,
// token 1085,
ves_icall_RuntimeTypeHandle_GetMetadataToken_raw,
// token 1087,
ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw,
// token 1097,
ves_icall_RuntimeTypeHandle_GetCorElementType,
// token 1098,
ves_icall_RuntimeTypeHandle_HasInstantiation,
// token 1099,
ves_icall_RuntimeTypeHandle_IsComObject_raw,
// token 1100,
ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw,
// token 1102,
ves_icall_RuntimeTypeHandle_HasReferences_raw,
// token 1109,
ves_icall_RuntimeTypeHandle_GetArrayRank_raw,
// token 1110,
ves_icall_RuntimeTypeHandle_GetAssembly_raw,
// token 1111,
ves_icall_RuntimeTypeHandle_GetElementType_raw,
// token 1112,
ves_icall_RuntimeTypeHandle_GetModule_raw,
// token 1113,
ves_icall_RuntimeTypeHandle_GetBaseType_raw,
// token 1121,
ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw,
// token 1122,
ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition,
// token 1123,
ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw,
// token 1127,
ves_icall_RuntimeTypeHandle_is_subclass_of_raw,
// token 1128,
ves_icall_RuntimeTypeHandle_IsByRefLike_raw,
// token 1130,
ves_icall_System_RuntimeTypeHandle_internal_from_name_raw,
// token 1134,
ves_icall_System_String_FastAllocateString_raw,
// token 1135,
ves_icall_System_String_InternalIsInterned_raw,
// token 1136,
ves_icall_System_String_InternalIntern_raw,
// token 1420,
ves_icall_System_Type_internal_from_handle_raw,
// token 1611,
ves_icall_System_ValueType_InternalGetHashCode_raw,
// token 1612,
ves_icall_System_ValueType_Equals_raw,
// token 9825,
ves_icall_System_Threading_Interlocked_CompareExchange_Int,
// token 9826,
ves_icall_System_Threading_Interlocked_CompareExchange_Object,
// token 9828,
ves_icall_System_Threading_Interlocked_Decrement_Int,
// token 9829,
ves_icall_System_Threading_Interlocked_Increment_Int,
// token 9830,
ves_icall_System_Threading_Interlocked_Increment_Long,
// token 9831,
ves_icall_System_Threading_Interlocked_Exchange_Int,
// token 9832,
ves_icall_System_Threading_Interlocked_Exchange_Object,
// token 9834,
ves_icall_System_Threading_Interlocked_CompareExchange_Long,
// token 9836,
ves_icall_System_Threading_Interlocked_Exchange_Long,
// token 9838,
ves_icall_System_Threading_Interlocked_Add_Int,
// token 9839,
ves_icall_System_Threading_Interlocked_Add_Long,
// token 9850,
ves_icall_System_Threading_Monitor_Monitor_Enter_raw,
// token 9852,
mono_monitor_exit_icall_raw,
// token 9859,
ves_icall_System_Threading_Monitor_Monitor_pulse_raw,
// token 9861,
ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw,
// token 9863,
ves_icall_System_Threading_Monitor_Monitor_wait_raw,
// token 9865,
ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw,
// token 9917,
ves_icall_System_Threading_Thread_InitInternal_raw,
// token 9918,
ves_icall_System_Threading_Thread_GetCurrentThread,
// token 9920,
ves_icall_System_Threading_InternalThread_Thread_free_internal_raw,
// token 9921,
ves_icall_System_Threading_Thread_GetState_raw,
// token 9922,
ves_icall_System_Threading_Thread_SetState_raw,
// token 9923,
ves_icall_System_Threading_Thread_ClrState_raw,
// token 9924,
ves_icall_System_Threading_Thread_SetName_icall_raw,
// token 9926,
ves_icall_System_Threading_Thread_YieldInternal,
// token 9928,
ves_icall_System_Threading_Thread_SetPriority_raw,
// token 11068,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw,
// token 11072,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw,
// token 11074,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw,
// token 11075,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw,
// token 11076,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw,
// token 11077,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw,
// token 11340,
ves_icall_System_GCHandle_InternalAlloc_raw,
// token 11341,
ves_icall_System_GCHandle_InternalFree_raw,
// token 11342,
ves_icall_System_GCHandle_InternalGet_raw,
// token 11343,
ves_icall_System_GCHandle_InternalSet_raw,
// token 11361,
ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError,
// token 11362,
ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError,
// token 11363,
ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw,
// token 11365,
ves_icall_System_Runtime_InteropServices_Marshal_SizeOfHelper_raw,
// token 11408,
ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw,
// token 11494,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw,
// token 11496,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalTryGetHashCode_raw,
// token 11498,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw,
// token 11508,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw,
// token 11509,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw,
// token 11510,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw,
// token 11511,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_RunClassConstructor_raw,
// token 11512,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack,
// token 11972,
ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw,
// token 11973,
ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw,
// token 11978,
ves_icall_System_Reflection_Assembly_InternalLoad_raw,
// token 11979,
ves_icall_System_Reflection_Assembly_InternalGetType_raw,
// token 12013,
ves_icall_System_Reflection_AssemblyName_GetNativeName,
// token 12033,
ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw,
// token 12040,
ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw,
// token 12047,
ves_icall_MonoCustomAttrs_IsDefinedInternal_raw,
// token 12058,
ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw,
// token 12062,
ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw,
// token 12088,
ves_icall_System_Reflection_LoaderAllocatorScout_Destroy,
// token 12169,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw,
// token 12171,
ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw,
// token 12182,
ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw,
// token 12184,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw,
// token 12185,
ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw,
// token 12186,
ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw,
// token 12193,
ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw,
// token 12208,
ves_icall_RuntimeEventInfo_get_event_info_raw,
// token 12228,
ves_icall_reflection_get_token_raw,
// token 12229,
ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw,
// token 12237,
ves_icall_RuntimeFieldInfo_ResolveType_raw,
// token 12239,
ves_icall_RuntimeFieldInfo_GetParentType_raw,
// token 12246,
ves_icall_RuntimeFieldInfo_GetFieldOffset_raw,
// token 12247,
ves_icall_RuntimeFieldInfo_GetValueInternal_raw,
// token 12250,
ves_icall_RuntimeFieldInfo_SetValueInternal_raw,
// token 12252,
ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw,
// token 12257,
ves_icall_reflection_get_token_raw,
// token 12263,
ves_icall_get_method_info_raw,
// token 12264,
ves_icall_get_method_attributes,
// token 12271,
ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw,
// token 12273,
ves_icall_System_MonoMethodInfo_get_retval_marshal_raw,
// token 12285,
ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw,
// token 12288,
ves_icall_RuntimeMethodInfo_get_name_raw,
// token 12289,
ves_icall_RuntimeMethodInfo_get_base_method_raw,
// token 12290,
ves_icall_reflection_get_token_raw,
// token 12301,
ves_icall_InternalInvoke_raw,
// token 12310,
ves_icall_RuntimeMethodInfo_GetPInvoke_raw,
// token 12316,
ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw,
// token 12317,
ves_icall_RuntimeMethodInfo_GetGenericArguments_raw,
// token 12318,
ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw,
// token 12320,
ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw,
// token 12321,
ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw,
// token 12338,
ves_icall_InvokeClassConstructor_raw,
// token 12340,
ves_icall_InternalInvoke_raw,
// token 12354,
ves_icall_reflection_get_token_raw,
// token 12376,
ves_icall_System_Reflection_RuntimeModule_GetGuidInternal_raw,
// token 12377,
ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw,
// token 12402,
ves_icall_RuntimeParameterInfo_GetTypeModifiers_raw,
// token 12407,
ves_icall_RuntimePropertyInfo_get_property_info_raw,
// token 12437,
ves_icall_reflection_get_token_raw,
// token 12438,
ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw,
// token 12984,
ves_icall_CustomAttributeBuilder_GetBlob_raw,
// token 12998,
ves_icall_DynamicMethod_create_dynamic_method_raw,
// token 13093,
ves_icall_AssemblyBuilder_basic_init_raw,
// token 13094,
ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw,
// token 13309,
ves_icall_ModuleBuilder_basic_init_raw,
// token 13310,
ves_icall_ModuleBuilder_set_wrappers_type_raw,
// token 13317,
ves_icall_ModuleBuilder_getUSIndex_raw,
// token 13318,
ves_icall_ModuleBuilder_getToken_raw,
// token 13319,
ves_icall_ModuleBuilder_getMethodToken_raw,
// token 13325,
ves_icall_ModuleBuilder_RegisterToken_raw,
// token 13423,
ves_icall_TypeBuilder_create_runtime_class_raw,
// token 13988,
ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw,
// token 13989,
ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw,
// token 14569,
ves_icall_System_Diagnostics_Debugger_IsAttached_internal,
// token 14570,
ves_icall_System_Diagnostics_Debugger_IsLogging,
// token 14571,
ves_icall_System_Diagnostics_Debugger_Log,
// token 14576,
ves_icall_System_Diagnostics_StackFrame_GetFrameInfo,
// token 14586,
ves_icall_System_Diagnostics_StackTrace_GetTrace,
// token 15562,
ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass,
// token 15583,
ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree,
// token 15585,
ves_icall_Mono_SafeStringMarshal_StringToUtf8,
// token 15587,
ves_icall_Mono_SafeStringMarshal_GFree,
};
static uint8_t corlib_icall_flags [] = {
0,
0,
0,
0,
0,
4,
4,
0,
4,
0,
4,
4,
4,
0,
0,
0,
4,
4,
4,
4,
4,
0,
4,
0,
0,
0,
4,
0,
4,
4,
4,
4,
0,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
};
