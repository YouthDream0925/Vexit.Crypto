namespace Vexit.Crypto
{
    public class MoneroClient
    {
        private RpcConnection _rpc;

        public MoneroClient(string uri)
        {
            _rpc = new RpcConnection(uri);
        }


        /* Monero Wallet RPC
         * 
set_daemon
get_balance 
get_address
get_address_index
create_address
label_address
validate_address
get_accounts
create_account
label_account
get_account_tags
tag_accounts
untag_accounts
set_account_tag_description
get_height
transfer
transfer_split
sign_transfer
submit_transfer
sweep_dust
sweep_all
sweep_single
relay_tx
store
get_payments
get_bulk_payments
incoming_transfers
query_key
make_integrated_address
split_integrated_address
stop_wallet
rescan_blockchain
set_tx_notes
get_tx_notes
set_attribute
get_attribute
get_tx_key
check_tx_key
get_tx_proof
check_tx_proof
get_spend_proof
check_spend_proof
get_reserve_proof
check_reserve_proof
get_transfers
get_transfer_by_txid
describe_transfer
sign
verify
export_outputs
import_outputs
export_key_images
import_key_images
make_uri
parse_uri
get_address_book
add_address_book
edit_address_book
delete_address_book
refresh
auto_refresh
rescan_spent
start_mining
stop_mining
get_languages
create_wallet
generate_from_keys
open_wallet
restore_deterministic_wallet
close_wallet
change_wallet_password
is_multisig
prepare_multisig
make_multisig
export_multisig_info
import_multisig_info
finalize_multisig
sign_multisig
submit_multisig
get_version

            */
    }
}
