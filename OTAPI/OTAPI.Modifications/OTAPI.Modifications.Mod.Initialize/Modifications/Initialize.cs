using OTAPI.Patcher.Engine.Extensions;
using OTAPI.Patcher.Engine.Modification;

namespace OTAPI.Patcher.Engine.Modifications.Hooks.Mod
{
	public class Initialize : ModificationBase
	{
		public override System.Collections.Generic.IEnumerable<string> AssemblyTargets => new[]
		{
			//"TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null",
			//"Terraria, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null",
			"Terraria, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null","TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null" // TML
		};
		public override string Description => "Hooking ModLoader.do_Load...";

		public override void Run()
		{
			var vanilla = this.SourceDefinition.Type("Terraria.ModLoader.ModLoader").Method("do_Load");

            var tmp = new object();
			var cbkBegin = this.Method(() => OTAPI.Callbacks.Terraria.Mod.InitializeBegin(ref tmp));
			var cbkEnd = this.Method(() => OTAPI.Callbacks.Terraria.Mod.InitializeEnd(ref tmp));

			vanilla.Wrap
			(
				beginCallback: cbkBegin,
				endCallback: cbkEnd,
				beginIsCancellable: false,
				noEndHandling: false,
				allowCallbackInstance: false
			);
		}
	}
}
