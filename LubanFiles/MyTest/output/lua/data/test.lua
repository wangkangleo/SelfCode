return
{
[1] = {id_t=1,y2={["aaa"]=1,["ccc"]=2,},y3={[10]="abc",[100]="def",},map_t={[1]={ID=1,Name=[["name_1"]],Price=666,},[2]={ID=2,Name=[["name_2"]],Price=6662,},[3]={ID=3,Name=[["name_3"]],Price=6663,},},array_t={{ID=1,Name=[["name_1"]],Price=666,},{ID=2,Name=[["name_2"]],Price=6662,},{ID=3,Name=[["name_3"]],Price=6663,},},},
[2] = {id_t=2,y2={["bbb"]=10,["ccc"]=20,["ddd"]=30,},y3={[20]="aaa",[100]="hello",[200]="world",},map_t={[1]={ID=1,Name=[["name_1"]],Price=666,},[2]={ID=2,Name=[["name_2"]],Price=6662,},[3]={ID=3,Name=[["name_3"]],Price=6663,},},array_t={{ID=1,Name=[["name_1"]],Price=666,},{ID=2,Name=[["name_2"]],Price=6662,},{ID=3,Name=[["name_3"]],Price=6663,},},},
[3] = {id_t=3,y2={["aaa"]=2,["ccc"]=38,},y3={[10]="eee",[20]="fff",[100]="ggg",},map_t={},array_t={{ID=1,Name=[["name_1"]],Price=666,},{ID=2,Name=[["name_2"]],Price=6662,},{ID=3,Name=[["name_3"]],Price=6663,},},},
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
    		id_t=1,
    		y2=
    	{
    		["aaa"]=1,
    		["ccc"]=2,
    	},
    	y3=
    	{
    		[10]="abc",
    		[100]="def",
    	},
    	map_t=
    	{
    		[1]=
    		{
    			ID=1,
    			Name=[["name_1"]],
    			Price=666,
    		},
    		[2]=
    		{
    			ID=2,
    			Name=[["name_2"]],
    			Price=6662,
    		},
    		[3]=
    		{
    			ID=3,
    			Name=[["name_3"]],
    			Price=6663,
    		},
    	},
    	array_t=
    	{
    				{
    			ID=1,
    			Name=[["name_1"]],
    			Price=666,
    		},
    				{
    			ID=2,
    			Name=[["name_2"]],
    			Price=6662,
    		},
    				{
    			ID=3,
    			Name=[["name_3"]],
    			Price=6663,
    		},
    	},
    },

    [2] = 
    {
    	id_t=2,
    	y2=
    	{
    		["bbb"]=10,
    		["ccc"]=20,
    		["ddd"]=30,
    	},
    	y3=
    	{
    		[20]="aaa",
    		[100]="hello",
    		[200]="world",
    	},
    	map_t=
    	{
    		[1]=
    		{
    			ID=1,
    			Name=[["name_1"]],
    			Price=666,
    		},
    		[2]=
    		{
    			ID=2,
    			Name=[["name_2"]],
    			Price=6662,
    		},
    		[3]=
    		{
    			ID=3,
    			Name=[["name_3"]],
    			Price=6663,
    		},
    	},
    	array_t=
    	{
    				{
    			ID=1,
    			Name=[["name_1"]],
    			Price=666,
    		},
    				{
    			ID=2,
    			Name=[["name_2"]],
    			Price=6662,
    		},
    				{
    			ID=3,
    			Name=[["name_3"]],
    			Price=6663,
    		},
    	},
    },

    [3] = 
    {
    	id_t=3,
    	y2=
    	{
    		["aaa"]=2,
    		["ccc"]=38,
    	},
    	y3=
    	{
    		[10]="eee",
    		[20]="fff",
    		[100]="ggg",
    	},
    	map_t=
    	{
    	},
    	array_t=
    	{
    				{
    			ID=1,
    			Name=[["name_1"]],
    			Price=666,
    		},
    				{
    			ID=2,
    			Name=[["name_2"]],
    			Price=6662,
    		},
    				{
    			ID=3,
    			Name=[["name_3"]],
    			Price=6663,
    		},
    	},
    },

}

local base = 
{
    __index = __default_value
}

setmetatable(ConfigData.,base)
return ConfigData.
