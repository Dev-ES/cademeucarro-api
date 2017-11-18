FROM microsoft/aspnetcore
COPY bin/Release/netcoreapp2.0/publish/ /root/
EXPOSE 80
WORKDIR /root
ENTRYPOINT dotnet cademeucarro-api.dll