import { AuthInfo } from "../objects/AuthInfo";
import { AuthInput } from "../objects/AuthInput";
import { Repository } from "./Repository";

class AuthRepository extends Repository<AuthInput, AuthInfo> {
  constructor() {
    super("api/auth");
  }

  async registration(authInput: AuthInput) {
    return await super.postWithData("reg", authInput);
  }

  async login(authInput: AuthInput) {
    return await super.postWithData("login", authInput);
  }

  async logout() {
    return await super.get("logout");
  }

  async getInfo() {
    return await super.get("getInfo");
  }
}

export const authRepository = new AuthRepository();
