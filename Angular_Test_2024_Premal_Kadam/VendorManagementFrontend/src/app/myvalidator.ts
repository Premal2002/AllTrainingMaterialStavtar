import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function dueDateValidator(recDate : Date) : ValidatorFn{
    return(control : AbstractControl) : ValidationErrors | null => {
        const dueDate : Date = new Date(control.value);
        
        const dateNotAllowed  = getDateWithoutTime(recDate) > getDateWithoutTime(dueDate);
        return dateNotAllowed ? {recDate : {value : control.value}} : null; 
    };
}

function getDateWithoutTime(date:Date) {
    return new Date(date.getFullYear(), date.getMonth(), date.getDate());
}