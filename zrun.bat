@echo off
setlocal

REM ============================================
REM Run this file from the directory it is in
cd /d "%~dp0"


electronize start /target "win-x64"


