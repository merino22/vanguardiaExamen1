import { Account } from "./account";

export interface Transaction {
  id: number;
  accountId: number;
  account: Account;
  amount: number;
  description: string;
}
