:: �������ַ���
echo %1
:: ��Ŀ������ַ
echo %2

:: ������
set nupkg=""

:: ����
dotnet msbuild %2 /p:Configuration=Release

:: ���
dotnet pack %2 -c Release --output ../nupkgs

:: ���°�����
for %%a in (dir /s /a /b "./nupkgs/%1") do (set nupkg=%%a)

:: ���Ͱ�
nuget push nupkgs/%nupkg% oy2m535fvjp7hu6yaprqvwmjzd73zjiu5ax3s2wu5agg2a -Source https://www.nuget.org/api/v2/package