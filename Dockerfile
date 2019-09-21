FROM mcr.microsoft.com/dotnet/core/sdk:2.2

WORKDIR /usr/src/app

COPY . .

RUN cd Collection
RUN dotnet restore
RUN dotnet build -c Release -o build_output

CMD [ "dotnet", "build_output/Collection.dll" ]