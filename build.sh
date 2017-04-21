#!/usr/bin/env bash
dotnet restore && npm install && npm run build:prod && ASPNETCORE_ENVIRONMENT=Production dotnet run