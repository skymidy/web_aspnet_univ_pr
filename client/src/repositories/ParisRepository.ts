import { PairsInfo } from "../objects/PairsInfo";
import { Repository } from "./Repository";

class ParisRepository extends Repository<string, PairsInfo> {
  constructor() {
    super("api/pairs");
  }

  async getPairsRecords() {
    return await super.get("");
  }
}

export const parisRepository = new ParisRepository();
