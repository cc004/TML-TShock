namespace OTAPI
{
    public static partial class Hooks
    {
        public static partial class Mod
        {
            #region Handlers
            public delegate void InitHandler(ref object threadContext);
            #endregion

            /// <summary>
            /// Occurs at the first point of call when the Initialze method is ran.
            /// </summary>
            public static InitHandler PreInitialize;

            /// <summary>
            /// Occurs at the end of the tmodloader initialize method.
            /// </summary>
            public static InitHandler PostInitialize;
        }
    }
}
