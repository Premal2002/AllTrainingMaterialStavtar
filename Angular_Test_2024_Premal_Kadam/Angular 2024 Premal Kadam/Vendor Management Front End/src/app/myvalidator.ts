import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function dueDateValidator(recDate : Date) : ValidatorFn{
    return(control : AbstractControl) : ValidationErrors | null => {
        const dueDate : Date = new Date(control.value);
        const dateNotAllowed  = recDate.getDate() > dueDate.getDate();
        return dateNotAllowed ? {recDate : {value : control.value}} : null; 
    };
}