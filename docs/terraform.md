# 8. Infraestructura como Código (Terraform)

## Estructura de archivos
- `provider.tf` - Configura proveedor AWS.
- `variables.tf` - Variables reutilizables.
- `main.tf` - Recursos principales o referencia a módulos.
- `networking.tf` - VPC, subredes.
- `compute.tf` - ECS, cluster, task.
- `security.tf` - Security Groups y roles.
- `outputs.tf` - Salidas de recursos.

## provider.tf
Configura AWS y el proveedor de Terraform.

## variables.tf
Define parámetros como región, CIDR y nombre de servicio.

## networking.tf
Define:
- VPC privada y pública.
- Subredes en múltiples AZ.
- Gateway NAT.
- Route tables.

## compute.tf
Define:
- ECS Cluster.
- Fargate Task Definition.
- Service asociado al ALB.

## security.tf
Define:
- Security Group para ALB.
- Security Group para ECS.
- Roles IAM para ejecución de tareas.

## outputs.tf
Devuelve:
- `alb_dns_name`
- `ecs_cluster_name`
- `service_name`
- `vpc_id`

## Comandos principales
```bash
terraform init
terraform fmt
terraform validate
terraform plan
terraform apply
```

## Notas
- MongoDB Atlas se administra fuera de Terraform AWS.
- Las credenciales de AWS se cargan desde variables de entorno.
