return
{
[1] = {ID=1,Limit=2,Flag=3,name="红水晶",},
[2] = {ID=2,Limit=3,Flag=3,name="治疗宝珠",},
[3] = {ID=3,Limit=3,Flag=3,name="生命药水",},
}
local __default_value =
{
   
       ID = 0,
       
       Limit = 0,
       
       Flag = 0,
       
       name = "",
       
}

ConfigData = ConfigData or {}
ConfigData.Sale=
{

    [1]=
    { 
        ID = 1,
        Limit = 2,
        Flag = 3,
        name = "红水晶",   
    },

    [2]=
    { 
        ID = 2,
        Limit = 3,
        Flag = 3,
        name = "治疗宝珠",   
    },

    [3]=
    { 
        ID = 3,
        Limit = 3,
        Flag = 3,
        name = "生命药水",   
    },

}

local base = 
{
    __index = __default_value
}

setmetatable(ConfigData.Sale,base)
return ConfigData.Sale
