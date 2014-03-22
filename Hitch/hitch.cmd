@echo off
hitchp.exe %*
IF %1.==-u GOTO end
IF %1.==-s GOTO end
IF %1.==--setup GOTO end
hitch_status.cmd
rm hitch_status.cmd
:end