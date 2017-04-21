#!/usr/bin/env bash
npm install && npm run build:prod && dotnet restore && ASPNETCORE_ENVIRONMENT=Production dotnet run