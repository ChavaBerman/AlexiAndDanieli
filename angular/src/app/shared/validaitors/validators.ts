import { ValidatorFn, FormGroup } from "@angular/forms";


/**
* @method 
* @param cntName the fromGroup control name 
* @param min min value the control must contain
* @param max max value the control can contain
* @return array of validators
*/
export function checkStringLength(cntName: string, min: number, max: number): Array<ValidatorFn> {
  return [
    f => !f.value ? { "val": `${cntName} is required` } : null,
    f => f.value && f.value.length > max ? { "val": `${cntName} is max ${max} chars` } : null,
    f => f.value && f.value.length < min ? { "val": `${cntName} is min ${min} chars` } : null,
    f => f.value && f.value.includes("'") ? { "val": `${cntName} can not contain '.` } : null
  ];
}

/**
* @method 
* @param cntName the fromGroup control name 
* @param min min value the control must contain
* @param max max value the control can contain
* @return array of validators
*/
export function checkInt(cntName: string, min: number, max: number): Array<ValidatorFn> {
  return [
    f => !f.value ? { "val": `${cntName} is required` } : null,
    f => f.value && f.value > max ? { "val": `${cntName} is max ${max}` } : null,
    f => f.value && f.value < min ? { "val": `${cntName} is min ${min}` } : null
  ];
}

/**
* @method 
* @param formgroup the whole group of controls  
* @return array of validators
*/
export function confirmPassword(formgroup: FormGroup): Array<ValidatorFn> {
  return [
    f => !f.value ? { "val": `confirm password is required` } : null,
    f => f.value && f.value != formgroup.get("password").value ? { "val": `confirm password does not match the passwords` } : null

  ];
}


/**
* @method 
* @param password the choosen password  
* @return array of validators
*/
export function checkEmail(): Array<ValidatorFn> {
  let emailPattern = /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$/;
  return [
    f => !f.value ? { "val": `Email is required` } : null,
    f => f.value && !f.value.match(/^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$/) ? { "val": `email address is not valid` } : null

  ];
}

/**
* @method 
* @param cntName the fromGroup control name 
* @return array of validators
*/
export function createValidatorDateBegin(cntName: string): Array<ValidatorFn>  {
  return [
    f => !f.value ? { "val": `${cntName} is required` } : null,
    f => f.value && new Date( f.value)<=new Date()? { "val": `${cntName} is less than today ` } : null,
  ];
}

/**
* @method 
* @param formgroup the whole group of controls  
* @return array of validators
*/
export function validateDateEnd(group: FormGroup) {
  return [
    f => !f.value ? { "val": `Date end is required` } : null,
    f => f.value && group.controls['dateBegin'].value>group.controls['dateEnd'].value? { "val": `Date end is less than date begin` } : null,
  ];

}