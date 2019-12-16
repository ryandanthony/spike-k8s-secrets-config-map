Push-Location ./src
dotnet msbuild /p:Configuration=Release /t:Restore,Build
Push-Location ./Kubernetes.Config.Example
	dotnet publish -c Release -f netcoreapp3.0  -r linux-x64 -o out
	docker build . -t "kubernetes-config-example:v1"
Pop-Location
Pop-Location