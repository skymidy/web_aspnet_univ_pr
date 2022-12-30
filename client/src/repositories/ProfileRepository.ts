import { ProfileInfo } from "../objects/ProfileInfo";
import { ProfileInput } from "../objects/ProfileInput";
import { Repository } from "./Repository";

class ProfileRepository extends Repository<ProfileInput, ProfileInfo> {
  constructor() {
    super("api/user");
  }

  async getProfile(user?: string) {
    return await super.get("" + (user ?? ""));
  }

  async updateProfile(input: ProfileInput) {
    return await super.postWithData("", input);
  }
}

export const profileRepository = new ProfileRepository();
