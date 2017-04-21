#!/usr/bin/env bash
nvm install "$(jq -r '.engines.node' package.json)" && npm install && npm run build:prod && dotnet restore && ASPNETCORE_ENVIRONMENT=Production dotnet run