#if IsWebApp
global using AntDesign.Pro.Template.Client.Resources;
#elif IsNotWebApp
global using AntDesign.Pro.Template.Resources;
#else 
global using AntDesign.Pro.Resources;
#endif

global using AntDesign;