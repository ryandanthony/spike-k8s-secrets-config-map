# spike-k8s-secrets-config-map
Spike to show how to use secrets and config maps for input 

Build the solution and the docker image
```
./build.ps1
```

switch to a local kubernetes cluster (docker-desktop)
```
kubectl config use-context docker-desktop
```

deploy to kuberetes.. (make sure you are using a local context)
```
cd deploy
kubectl apply -f .\deploy.yml
```

Get a list of pods
```
kubectl get pods
```

Get log from pod to see the config printed out to the console
```
kubectl logs {name of pod}
```