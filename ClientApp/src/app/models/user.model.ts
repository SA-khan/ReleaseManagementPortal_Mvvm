export class User {
  constructor(
    public userId?: number,
    public firstName?: string,
    public middleName?: string,
    public lastName?: string,
    public logo?: string,
    public loginName?: string,
    public phoneExtension?: string,
    public mobile?: string,
    public clientPoc?: boolean,
    public processed?: boolean,
    public enabled?: boolean,
    public createdOn?: string,
    public modifiedOn?: string,
    public loggedIn?: string,
    public lastLoginDate?: string,
    public currentPassword?: string,
    public wrongAttemptCount?: number,
    public lastPassword1?: string,
    public lastPassword2?: string,
    public lastPassword3?: string,
    public lastPassword4?: string,
    public passwordPolicy?: string,
    public question1?: string,
    public answer1?: string,
    public question2?: string,
    public answer2?: string,
    public question3?: string,
    public answer3?: string,
    public changePasswordDate?: string,
    public language?: string,
    public theme?: string,
    public region?: string,
    public termsAgreeed?: boolean ) { }
}
