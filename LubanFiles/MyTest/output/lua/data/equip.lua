return
{
[1] = {ID=1,Name="攻击之爪",Price=450,},
[2] = {ID=2,Name="加速手套",Price=425,},
[3] = {ID=3,Name="速度之靴",Price=500,},
}
local __default_value =
{
   
       ID = 0,
       
       Name = "",
       
       Price = 0,
       
}

ConfigData = ConfigData or {}
ConfigData.Equip=
{

    [1]=
    { 
        ID = 1,
        Name = "攻击之爪",
        Price = 450,   
    },

    [2]=
    { 
        ID = 2,
        Name = "加速手套",
        Price = 425,   
    },

    [3]=
    { 
        ID = 3,
        Name = "速度之靴",
        Price = 500,   
    },

}

local base = 
{
    __index = __default_value
}

setmetatable(ConfigData.Equip,base)
return ConfigData.Equip
