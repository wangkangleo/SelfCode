return
{
[1] = {ID=1,Limit=2,Flag=3,name="红水晶",},
[2] = {ID=2,Limit=3,Flag=3,name="治疗宝珠",},
[3] = {ID=3,Limit=3,Flag=3,name="生命药水",},
}
local __default_value =
{
   
       [1] = {},
       
       [2] = {},
       
       [3] = {},
       
}

ConfigData = ConfigData or {}
ConfigData.=
{

    [1] = 
    {
    			ID=1,
    			Limit=2,
    			Flag=3,
    			name="红水晶",
    		},

    [2] = 
    		{
    			ID=2,
    			Limit=3,
    			Flag=3,
    			name="治疗宝珠",
    		},

    [3] = 
    	{
    		ID=3,
    		Limit=3,
    		Flag=3,
    		name="生命药水",
    	},

}

local base = 
{
    __index = __default_value
}

setmetatable(ConfigData.,base)
return ConfigData.
