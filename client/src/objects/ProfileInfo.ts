import { RoleType } from "../enums/RoleType";
import { PairRecord } from "./PairRecord";
import { ProfileInput } from "./ProfileInput";

export type ProfileInfo = {
  id: string;
  loginName: string;
  role: RoleType;
  userProfile: ProfileInput;
  errorMessage: string;
};
