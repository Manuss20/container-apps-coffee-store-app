#Commons
variable "location" {
  description = "(Required) Location of the all services to be created"
  default="westeurope"
}

variable "resource_group_name" {
  description = "(Required) Resource group name of the all services to be created"
  default= "coffeecapp"
}

variable "tags" {
  description = "(Required) Tags to be applied to the all services to be created"
  default = { Project = "coffeecapp", Owner = "Manuel Sanchez", Environment = "Dev" }
}
