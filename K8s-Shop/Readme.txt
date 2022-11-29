If after Docker Desktop installation , the initialisation fails simply restart the machine or log-off

Set alias of kubectl to k in powershell 
-----------------------------------------------------------------------------------------
https://4sysops.com/archives/how-to-create-a-powershell-alias/
Set-alias <alias name> <the actual command>

For Multi-Container scenario
------------------------------------------------------------------------------------------
1. Could have multiple container defined with same image but their conatiner name has to be different
2. If we even scale , the scale parameter would applied to a specific container. It applies 
   that if a spefic container will scale as per the spec were other conatiner would not though their image is same.
3. when you fire kubectl exec -it -- command <<command name>> to enter inside a pod it basically connect you 
   on of the running container. If you do no specify the container name in the command then it is defaulted to 
   the first container as you defined in the conatiner spec of your deployment.yaml file

The config location of aks cluster context
-----------------------------------------------------------------------------------------
az aks get-credentials --resource-group <<>> --name <<cluster name>>
Merged "aksk8sexp" as current context in C:\Users\nilesh.mitra\.kube\config

The difference between GB vs GiB
------------------------------------------------------------------------------------------
https://massive.io/file-transfer/gb-vs-gib-whats-the-difference/#gb-vs-gib-so-what-is-the-difference

How PVC reference PV in AKS cluster
---------------------------------------------------------------------------------------------
https://www.kubermatic.com/blog/keeping-the-state-of-apps-4-persistentvolumes-and-persistentvolum/#:~:text=PVs%20are%20cluster%20resources%20provisioned,context%20of%20cluster%20resource%20consumption.

Kubernetes PersistentVolumes (PVs) and PersistentVolumeClaims (PVCs)
Storage management is essential in Kubernetes, especially in  large environments where many users deploy multiple 
Pods. The users in this environment often need to configure storage for each Pod, and when making a change to 
existing applications, it must be made on all Pods, one after the other. 
To mitigate this time-consuming scenario and separate the details of how storage is provisioned 
from how it is consumed, we use PersistentVolumes (PVs) and PersistentVolumeClaims (PVCs).

A PersistentVolume (PV) in Kubernetes is a pool of pre-provisioned storage resources in a Kubernetes cluster, 
that can be used across different user environments. 
Its lifecycle is separate from a Pod that uses the PersistentVolume.

A PersistentVolumeClaim (PVC), is a process of storage requests from PVs by the users in Kubernetes. 
Kubernetes binds PVs with the PVCs based on the request and property set on those PVs. 
Kubernetes searches for PVs that correspond to the PVCs’ requested capacity and specified properties, 
so that each PVC can bind to a single PV.
When there are multiple matches, you can use labels and selectors to bind a PVC to the right or a particular PV. 
This helps guard against a situation where a small PVC binds to a larger PV, since PVs and PVCs 
have a one-to-one relationship. 
When this happens, the remaining storage in the bound PVs are inaccessible to other users.

NOTE: Both the PVCs and the Pod using them must be in the same namespace.
