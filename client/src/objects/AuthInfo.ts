import { RoleType } from "../enums/RoleType";

export type AuthInfo = {
  isAuthenticated: boolean;
  role: RoleType;
  loginName: string;
  errorMessage: string;
};
