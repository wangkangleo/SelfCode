set config_root_path=.
set LUBAN_DLL=.\bin\Luban.dll
set output_server_proto_path=.\output\server\proto
set output_server_proto_data_path=.\output\server\protodata
set output_client_code_path=.\output\client\code
set output_client_data_path=.\output\client\data
set output_lua_data_path=.\output\luadata

dotnet %LUBAN_DLL% ^
    -t client ^
	-c cs-bin ^
	-d bin ^
    --conf %config_root_path%\luban.conf ^
    -x outputCodeDir=%output_client_code_path% ^
    -x outputDataDir=%output_client_data_path%

dotnet %LUBAN_DLL% ^
    -t server ^
	-c protobuf3 ^
	-d protobuf3-bin ^
    --conf %config_root_path%\luban.conf ^
    -x outputCodeDir=%output_server_proto_path% ^
    -x outputDataDir=%output_server_proto_data_path%
	
dotnet %LUBAN_DLL% ^
    -t all ^
	-d lua ^
    --conf %config_root_path%\luban.conf ^
    -x outputDataDir=%output_lua_data_path%

pause