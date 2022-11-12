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
