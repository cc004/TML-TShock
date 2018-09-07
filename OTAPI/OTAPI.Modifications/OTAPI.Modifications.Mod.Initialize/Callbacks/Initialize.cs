namespace OTAPI.Callbacks.Terraria
{
    internal static partial class Mod
    {
        /// <summary>
        /// This method is injected to the beginning of the tmodloader Initialize method.
        /// </summary>
        internal static void InitializeBegin(ref object threadContext) => Hooks.Mod.PreInitialize?.Invoke(ref threadContext);

		/// <summary>
		/// This method is injected into the end of the tmodloader Initialize method.
		/// </summary>
		internal static void InitializeEnd(ref object threadContext) => Hooks.Mod.PostInitialize?.Invoke(ref threadContext);
    }
}
